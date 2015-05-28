using System.Collections.Generic;
using Pillar.Domain;

namespace Asam.Ppc.Domain.AssessmentModule
{
    public interface IAssessmentRepository : IRepository<Assessment>
    {
        List<Assessment> GetAllAssessmentsByKeyword(string keyword, int pageIndex, int pageSize, out int totalCount);

        IEnumerable<Assessment> GetPagedAssessmentsByPatientId(long patientId,
                                                               int pageIndex,
                                                               int pageSize,
                                                               out int totalCount);

        void Evict(Assessment assessment);

        Assessment GetUnproxiedAssessment(Assessment assessment);
    }
}