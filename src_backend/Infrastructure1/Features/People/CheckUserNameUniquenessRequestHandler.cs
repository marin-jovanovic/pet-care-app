

using Infrastructure.EFModel;

namespace Domain.Validation.People
{
    public class CheckUserNameUniquenessRequestHandler
    {
        private readonly ProjectContext ctx;

        public CheckUserNameUniquenessRequestHandler(ProjectContext ctx)
        {
            this.ctx = ctx;
        }

    }
}
