using PhanNguyen_DemoAPI.Data;

namespace PhanNguyen_DemoAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {

        }
    }
}
