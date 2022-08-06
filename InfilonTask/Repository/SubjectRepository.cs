using InfilonTask.Models;
using Newtonsoft.Json;

namespace InfilonTask.Repository
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly AppDbContext _dbContext;

        public SubjectRepository(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }
        public List<Subject> GetSubjectData()
        {
            return _dbContext.Subjects.ToList();
        }

        public Subject GetSubjectDataById(int id)
        {
            return _dbContext.Subjects.FirstOrDefault(item => item.Id == id);
        }

        public async Task<IEnumerable<Subject>> PostSubjectDataFromApiToDatabase()
        {
            // Get data from api. 
            List<Subject> subjectList = new List<Subject>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    subjectList = JsonConvert.DeserializeObject<List<Subject>>(apiResponse);
                }
            }

            _dbContext.Subjects.AddRange(subjectList);

            await _dbContext.SaveChangesAsync();

            return _dbContext.Subjects;
        }

        public void UpdateSubject(Subject subject)
        {
            _dbContext.Subjects.Update(subject);

            _dbContext.SaveChanges();
        }
    }
}

    

