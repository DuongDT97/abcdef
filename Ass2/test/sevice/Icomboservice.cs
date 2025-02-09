using test.Model;

namespace test.Service
{
    public interface Icomboservice
    {
       public IEnumerable<Combos> GetCombos();
        public Combos Create(Combos combos);
        public Combos Update(Combos combos);
        public void Delete(int id);
    }
}
