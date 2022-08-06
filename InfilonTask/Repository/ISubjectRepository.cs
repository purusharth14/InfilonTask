using InfilonTask.Models;

namespace InfilonTask.Repository
{
    public interface ISubjectRepository
    {
        public Task<IEnumerable<Subject>> PostSubjectDataFromApiToDatabase();

        public List<Subject> GetSubjectData();

        public void UpdateSubject(Subject subject);

        Subject GetSubjectDataById(int id);
    }
}
