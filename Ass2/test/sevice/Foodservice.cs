using System.Collections.Generic;
using test.Model;

namespace test.Service
{
    public class Foodservice : Ifoodservice
    {
        private readonly Dbcon _dbcon;
        public Foodservice(Dbcon dbcon)
        {
            _dbcon = dbcon;
        }
        
        public Food Addfood(Food food)
        {           
            _dbcon.Foods.Add(food);
            _dbcon.SaveChanges();
            return food;
        }
        public List<Food> GetFoodList() 
        {
            return _dbcon.Foods.ToList();

        }
        public Food GetFoodid(int id) 
        {
            var food =  _dbcon.Foods.FirstOrDefault(f => f.MonAnID == id);
            return food;
        }
        public Food Updatefood(Food food) 
        {
            var existingFood = _dbcon.Foods.Find(food.MonAnID);
            if (existingFood != null)
            {
                // Cập nhật các thuộc tính của thực phẩm hiện có
                existingFood.MoTa = food.MoTa;
                existingFood.SoLuong = food.SoLuong;
                existingFood.Ten = food.Ten;
                existingFood.Gia = food.Gia;
                existingFood.HinhAnh = food.HinhAnh;
                existingFood.Loai = food.Loai;
                existingFood.TinhTrang = food.TinhTrang;

                _dbcon.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            return existingFood; // Trả về thực phẩm đã cập nhật
        }
        public void Delete(int id)
        {
            var food = _dbcon.Foods.Find(id);
            if(food != null)
            {
                _dbcon.Remove(food);
               
            }
            _dbcon.SaveChanges();
        }
    }
}

