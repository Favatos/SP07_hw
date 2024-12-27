namespace SP07_hw
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task task1 = EncryptFile("file1.txt", "result1.txt");
            Task task2 = EncryptFile("file2.txt", "result2.txt");
            Task task3 = EncryptFile("file3.txt", "result3.txt");
            Task task4 = EncryptFile("file4.txt", "result4.txt");
            await Task.WhenAll(task1, task2, task3, task4);

        }

        private static async Task EncryptFile(string fromFilename, string toFilename)
        {
            using Stream @in = File.OpenRead(fromFilename);
            using Stream @out = File.Create(toFilename);
            byte[] buffer = new byte[1024];

            int read;

            while ((read = await @in.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                for (int i = 0; i < read; i++)
                {
                    buffer[i]++;
                }

                await @out.WriteAsync(buffer, 0, read);
            }
        }
    }
}
