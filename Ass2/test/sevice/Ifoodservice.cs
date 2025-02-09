using test.Model;

namespace test.Service
{
    public interface Ifoodservice
    {
       public Food GetFoodid(int id);
        public List<Food> GetFoodList();
         public  Food Addfood(Food food);
       public Food Updatefood(Food food);
       public void Delete(int id);
      
    }
}
