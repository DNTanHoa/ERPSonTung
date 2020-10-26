using ERP.Model.Models;

namespace ERP.Repository
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Candidate GetByCode(string code);
    }
}