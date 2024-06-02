namespace _5by5.Utils
{
    public class EditorArquivo
    {
        private readonly string CaminhoDiretorio;
        private readonly string CaminhoArquivo;

        public EditorArquivo(string diretorio, string arquivo)
        {
            CaminhoDiretorio = diretorio;
            CaminhoArquivo = arquivo;

            if (!Directory.Exists(CaminhoDiretorio))
                Directory.CreateDirectory(CaminhoDiretorio);

            if (!File.Exists(CaminhoDiretorio + CaminhoArquivo))
            {
                var aux = File.Create(CaminhoDiretorio + CaminhoArquivo);
                aux.Close();
            }
        }

        public int Read() => int.TryParse(File.ReadAllText(CaminhoDiretorio + CaminhoArquivo).ToString(), out int current) ? current : 0;

        public List<string> ReadNumbers() => File.ReadAllLines(CaminhoDiretorio + CaminhoArquivo).ToList();

        public void Save(int current) => File.WriteAllText(CaminhoDiretorio + CaminhoArquivo, current.ToString());
    }
}