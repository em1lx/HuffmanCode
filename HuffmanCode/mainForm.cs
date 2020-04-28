using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HuffmanCode
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            inputTextBox.Select();
            ShowIcon = false;
        }

        class Node
        {
            public string symbol;
            public int frequence;
            public Node leftNode;
            public Node rightNode;

            public Node() { }

            public Node(Node leftNode, Node rightNode)
            {
                this.leftNode = leftNode;
                this.rightNode = rightNode;
                this.frequence = this.leftNode.frequence + this.rightNode.frequence;
            }
        }

        int countOfBits = 0;
        bool check = false;

        List<int> outputBits = new List<int>();
        List<int> inputBits = new List<int>();
        Dictionary<string, int> symbols = new Dictionary<string, int>();
        Dictionary<string, List<int>> codeTable = new Dictionary<string, List<int>>();

        private void saveInputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Document (*.txt)|*.txt|BIN File (*.bin)|*.bin|All files (*.*)|*.*";

            if (saveFile.ShowDialog().Equals(DialogResult.OK))
            {
                using (FileStream fstream = File.Open(saveFile.FileName, FileMode.Create))
                {
                    if (saveFile.FileName.Contains(".bin"))
                    {
                        check = true;
                        byte result;
                        int count;

                        for (int i = inputTextBox.TextLength - 1; i >= 0; i--)
                        {
                            count = 0; result = 0;
                            for (byte b = 1; i >= 0; b <<= 1, i--)
                            {
                                ++count; ++countOfBits;
                                if (inputTextBox.Text[i].ToString().Equals("1"))
                                    result |= b;
                                if (count.Equals(8))
                                    break;
                            }
                            fstream.WriteByte(result);
                        }
                    }
                    else
                    {
                        byte[] data = new byte[fstream.Length];
                        data = System.Text.Encoding.Default.GetBytes(inputTextBox.Text);
                        fstream.Write(data, 0, data.Length);
                    }
                }
            }
        }

        private void saveOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "BIN File (*.bin)|*.bin|Text Document (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFile.ShowDialog().Equals(DialogResult.OK))
            {
                using (FileStream fstream = File.Open(saveFile.FileName, FileMode.Create))
                {
                    if (saveFile.FileName.Contains(".bin"))
                    {
                        check = false;
                        outputBits.Reverse();
                        byte result;
                        int count;

                        for (int i = 0; i < outputBits.Count(); i++)
                        {
                            count = 0; result = 0;
                            for (byte b = 1; i < outputBits.Count(); b <<= 1, i++)
                            {
                                ++count;
                                if (outputBits[i].Equals(1))
                                    result |= b;
                                if (count.Equals(8))
                                    break;
                            }
                            fstream.WriteByte(result);
                        }
                        outputBits.Reverse();
                    }
                    else
                    {
                        byte[] data = new byte[fstream.Length];
                        data = System.Text.Encoding.Default.GetBytes(outputTextBox.Text);
                        fstream.Write(data, 0, data.Length);
                    }
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Document (*.txt)|*.txt|BIN File (*.bin)|*.bin|All files (*.*)|*.*";

            if (openFile.ShowDialog().Equals(DialogResult.OK))
            {
                inputTextBox.Clear();
                outputTextBox.Clear();

                using (FileStream fstream = File.Open(openFile.FileName, FileMode.Open))
                {
                    if (openFile.FileName.Contains(".bin"))
                    {
                        compressButton.Enabled = false;
                        recoverButton.Enabled = true;

                        if (!check)
                            countOfBits = outputBits.Count();
                        inputBits.Clear();

                        byte[] data = new byte[fstream.Length];
                        fstream.Read(data, 0, data.Length);

                        for (int i = 0; i < data.Length; i++)
                        {
                            byte b = data[i];
                            for (int j = 0; j < 8; j++)
                            {
                                --countOfBits;
                                if (!(b & (1 << j)).Equals(0))
                                    inputBits.Add(1);
                                else inputBits.Add(0);

                                if (countOfBits.Equals(0))
                                    break;
                            }
                        }
                        inputBits.Reverse();

                        foreach (var bit in inputBits)
                            inputTextBox.AppendText(bit.ToString());
                    }
                    else
                    {
                        compressButton.Enabled = true;
                        recoverButton.Enabled = false;

                        byte[] data = new byte[fstream.Length];
                        fstream.Read(data, 0, data.Length);
                        inputTextBox.Text = System.Text.Encoding.Default.GetString(data);
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
            outputTextBox.Clear();
            recoverButton.Enabled = true;
            compressButton.Enabled = true;
        }

        public void symbolsFrequency()
        {
            for (int i = 0; i < inputTextBox.TextLength; i++)
            {
                string symbol = inputTextBox.Text[i].ToString();
                if (symbol.Equals("\n")) symbol = "Newline";
                if (symbol.Equals(" ")) symbol = "Space";

                if (!symbols.ContainsKey(symbol))
                    symbols.Add(symbol, 1);
                else symbols[symbol]++;
            }
        }

        public void createTree()
        {
            LinkedList<Node> nodes = new LinkedList<Node>();
            foreach (var item in symbols.OrderBy(item => item.Value))
            {
                Node node = new Node();
                node.symbol = item.Key;
                node.frequence = item.Value;
                nodes.AddLast(node);
            }

            while (!nodes.Count().Equals(1))
            {
                nodes = new LinkedList<Node>(nodes.OrderBy(item => item.frequence));
                Node leftNode = new Node(); leftNode = nodes.First(); nodes.RemoveFirst();
                Node rightNode = new Node(); rightNode = nodes.First(); nodes.RemoveFirst();

                Node sourceNode = new Node(leftNode, rightNode);
                nodes.AddLast(sourceNode);
            }
            Node rootNode = new Node();
            rootNode = nodes.First();

            code.Clear();
            createCodeTable(rootNode);
        }

        List<int> code = new List<int>();

        private void createCodeTable(Node node)
        {
            if (node.leftNode != null)
            {
                code.Add(0);
                createCodeTable(node.leftNode);
            }
            if (node.rightNode != null)
            {
                code.Add(1);
                createCodeTable(node.rightNode);
            }
            if (node.symbol != null)
                codeTable.Add(node.symbol, code.ToList());

            if (!code.Count.Equals(0))
            {
                code.Reverse();
                code.Remove(code.First());
                code.Reverse();
            }
        }

        private void showAnalysis()
        {
            symbols = symbols.OrderBy(item => item.Key).ToDictionary(item => item.Key, item => item.Value);
            codeTable = codeTable.OrderBy(item => item.Key).ToDictionary(item => item.Key, item => item.Value);

            analysisTextBox.AppendText("Symbol\t\tFrequency\tCode\n");
            string[] codes = new string[codeTable.Count()];
            int index = 0;
            
            foreach (var item in codeTable)
            {
                List<int> code = new List<int>(item.Value);
                foreach (var key in code)
                    codes[index] += key.ToString();
                ++index;
            }
            index = 0;

            foreach (var item in symbols)
                analysisTextBox.AppendText($"{item.Key}\t\t{item.Value}\t\t{codes[index++]}\n");
        }

        private void compressionData()
        {
            outputBits = new List<int>();
            string symbol;

            for (int i = 0; i < inputTextBox.TextLength; i++)
            {
                if (inputTextBox.Text[i].ToString().Equals(" "))
                    symbol = "Space";
                else if (inputTextBox.Text[i].ToString().Equals("\n"))
                    symbol = "Newline";
                else symbol = inputTextBox.Text[i].ToString();

                if (codeTable.ContainsKey(symbol))
                {
                    foreach (var item in codeTable)
                    {
                        if (item.Key == symbol)
                        {
                            List<int> code = new List<int>(item.Value);
                            foreach (var key in code)
                                outputBits.Add(key);
                        }
                    }
                }
            }
            foreach (var bit in outputBits)
                outputTextBox.AppendText(bit.ToString());
        }

        private void recoveryData()
        {
            inputBits.Clear();

            for (int i = 0; i < inputTextBox.TextLength; i++)
            {
                if (inputTextBox.Text[i].ToString().Equals("1"))
                    inputBits.Add(1);
                else if (inputTextBox.Text[i].ToString().Equals("0")) inputBits.Add(0);
            }
            int index = 0;
            List<int> checkCode = new List<int>();

            for (; index < inputBits.Count(); index++)
            {
                checkCode.Add(inputBits[index]);
                foreach (var item in codeTable)
                {
                    List<int> code = new List<int>(item.Value);
                    if (checkCode.SequenceEqual(code))
                    {
                        if (item.Key.Equals("Space"))
                            outputTextBox.AppendText(" ");
                        else if (item.Key.Equals("Newline"))
                            outputTextBox.AppendText("\n");
                        else outputTextBox.AppendText(item.Key);

                        checkCode.Clear();
                    }
                }
            }
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            symbols.Clear();
            codeTable.Clear();
            try
            {
                if (inputTextBox.Text.Length.Equals(0))
                    throw new Exception("Cannot perform this operation!");
                analysisTextBox.Clear();
                outputTextBox.Clear();

                symbolsFrequency();
                createTree();
                showAnalysis();
                compressionData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void recoverButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (analysisTextBox.Text.Length.Equals(0) || inputTextBox.Text.Length.Equals(0))
                    throw new Exception("Cannot perform this operation!");
                outputTextBox.Clear();

                recoveryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
