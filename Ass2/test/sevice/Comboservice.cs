using test.Model;

namespace test.Service
{
    public class Comboservice
    {
        private readonly Dbcon _dbcon;
        public Comboservice(Dbcon dbcon) { _dbcon = dbcon; }
        public IEnumerable<Combos> Combos()
        {
            return _dbcon.Combos.ToList();
        }
        public Combos Create(Combos combos) 
        {
            _dbcon.Combos.Add(combos);
            _dbcon.SaveChanges();
            return combos;
        
        }
        public void Delete(int id) 
        {
            var tim = _dbcon.Combos.Find(id);
            if (tim != null) 
            {
                _dbcon.Combos.Remove(tim);
                _dbcon.SaveChanges();
            }
        
        }
        public Combos Update(Combos combos) 
        {
            var combofi = _dbcon.Combos.Find(combos.ComboID);
            if (combofi != null) 
            {
                combofi.MoTa = combos.MoTa;
                combofi.Gia = combos.Gia;
                combofi.LoaiCombo = combos.LoaiCombo;
                combofi.HinhAnh = combos.HinhAnh;
                combofi.Ten = combofi.Ten;
                _dbcon.Update(combofi);
                _dbcon.SaveChanges();
                return combofi;             
            }
            return null;

        }
    }
}
