namespace SnipView
{
    internal static class Program
    {
        static readonly string AppName = "SnipViewProgram";

        [STAThread]
        static void Main()
        {
            using (var mutex = new Mutex(false, AppName, out bool createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("Another instance of the application is already running.", "SnipView", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                ApplicationConfiguration.Initialize();
                Application.Run(new Main());
            }
        }
    }
}