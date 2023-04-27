namespace ExamBannedWords
{
    internal static class Program
    {
        public static Mutex mutex = new Mutex(true, "ExamBannedWords");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Приложение уже запущено.");
            }           
        }
    }
}