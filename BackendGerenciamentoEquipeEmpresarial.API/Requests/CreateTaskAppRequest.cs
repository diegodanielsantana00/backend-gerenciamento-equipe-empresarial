namespace BackendGerenciamentoEquipeEmpresarial.API.Requests
{
    public class CreateTaskAppRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoryPoints { get; set; }
        public int Project { get; set; }
        public int UserResponsible { get; set; }
        public int StatusTask { get; set; }
        public int PriorityTask { get; set; }
    }
}
