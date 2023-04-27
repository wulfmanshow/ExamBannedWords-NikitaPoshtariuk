namespace ExamBannedWords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mutex.ReleaseMutex();
        }

        private void CopyAndReplaceTextFiles(string sourceDirectory, string destinationDirectory, string[] searchWords, int maxThreads, Dictionary<string, int> bannedWords)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirectory);
            FileInfo[] files = dir.GetFiles("*.txt", SearchOption.AllDirectories);

            int totalFiles = files.Length;
            int filesPerThread = totalFiles / maxThreads;
            int remainingFiles = totalFiles % maxThreads;


            List<List<FileInfo>> filesByThread = new List<List<FileInfo>>();
            int index = 0;
            for (int i = 0; i < maxThreads; i++)
            {
                int count = filesPerThread;
                if (remainingFiles > 0)
                {
                    count++;
                    remainingFiles--;
                }
                List<FileInfo> threadFiles = files.Skip(index).Take(count).ToList();
                filesByThread.Add(threadFiles);
                index += count;
            }

            foreach (List<FileInfo> threadFiles in filesByThread)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    foreach (FileInfo file in threadFiles)
                    {
                        bool fileContainsSearchWord = false;
                        List<string> lines = new List<string>();
                        using (StreamReader reader = new StreamReader(file.FullName))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                foreach (string searchWord in searchWords)
                                {
                                    if (line.Contains(searchWord))
                                    {
                                        if (bannedWords.ContainsKey(searchWord))
                                        {
                                            bannedWords[searchWord]++;
                                        }
                                        else
                                        {
                                            bannedWords[searchWord] = 1;
                                        }
                                        fileContainsSearchWord = true;
                                        line = line.Replace(searchWord, "*******");
                                    }
                                }
                                lines.Add(line);
                            }
                        }

                        if (fileContainsSearchWord)
                        {
                            string destinationFile = Path.Combine(destinationDirectory, file.Name);
                            using (StreamWriter writer = new StreamWriter(destinationFile))
                            {
                                foreach (string line in lines)
                                {
                                    writer.WriteLine(line);
                                }
                            }
                        }
                    }
                });
            }
            Thread.Sleep(100); // wait for threads to start
            ThreadPool.SetMaxThreads(maxThreads, maxThreads);
            while (ThreadPool.PendingWorkItemCount > 0)
            {
                Thread.Sleep(100);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            string sourceDirectory = @"D:\Source\";
            string destinationDirectory = @"D:\Destination\";
            int size = comboBox1.Items.Count;
            string[] mass = new string[size];
            Dictionary<string, int> BannedWords = new Dictionary<string, int>();
            for (int i = 0; i < size; i++)
            {
                mass[i] = (string)comboBox1.Items[i];
                BannedWords.Add((string)comboBox1.Items[i], 0);
            }

            CopyAndReplaceTextFiles(sourceDirectory, destinationDirectory, mass, 4, BannedWords);
            string bannedWordsFile = Path.Combine(destinationDirectory, "bannedWords.txt");
            using (StreamWriter writer = new StreamWriter(bannedWordsFile))
            {
                foreach (KeyValuePair<string, int> bannedWord in BannedWords)
                {
                    writer.WriteLine(bannedWord.Key + ": " + bannedWord.Value);
                }
            }
            MessageBox.Show("All files already coppyed");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }
    }
}
