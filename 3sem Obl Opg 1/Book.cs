namespace _3sem_Obl_Opg_1
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }

        public void TitleValidator()
        {
            if(Title == null)
            {
                throw new ArgumentNullException("Title must not be null.");
            }
            if(Title.Length < 3)
            {
                throw new ArgumentException("Title must be 3 or more letters.");
            }
        }

        public void PriceValidator()
        {
            if(Price < 0 || Price >= 1200){
                throw new ArgumentOutOfRangeException("Price must be between 0 and 1200.");
            }
        }


    }
}