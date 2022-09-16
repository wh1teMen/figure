using System;
using System.IO;

namespace ConsoleApp12
{
      public delegate void Mydeliegat();
   // public delegate void Mydeliegat(string a);

    public abstract class GeoFigure
    {
        public string name;
        public string _path;

        public GeoFigure()
        {
            name = "Фигура"; _path = "out.txt";
        }


        private bool Scalable;
        public bool scalable {
            get { return Scalable; }
            set { Scalable = value; }
        }


        public void Printname() => Console.WriteLine(this.name);
        public abstract float Square();
        public virtual float Square(float _metric)
        {
            return _metric;
        }
       
    }


    public class Circle : GeoFigure
    {

        public event Mydeliegat _notify
        {
            add => _notify += value;
            remove => _notify -= value;
        }
        protected string  name="Окружность";
        public float _radius;
        public Circle() { name = this.name; }
        

       
        public override float Square() {
        float _result = (_radius * _radius) * 3.14f;
        float _limit = 100f;
        if(_result>_limit)
            {
                // _notify?.Invoke("Площадь окружности больше 100");
                _notify+=informer_console;
               
            }

            return _result;
        }
       
        public override float Square(float _metric)
        {
            return (_radius * _radius) * 3.14f;
        }
        public  float Square(float _metric, bool IsBase)
        {
            if (IsBase)
            {
                return base.Square(_metric);
            }
            {
                return Square(_metric);
            }
           
        }
        public  void Print_square() => Console.WriteLine("Площадь={0}",this.Square(this._radius));
        public void Print_square(bool IsBase) => Console.WriteLine("Площадь={0}", this.Square(this._radius,IsBase));
        public void Write_square()
        {
            string full_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var sw = new StreamWriter(full_path+"\\"+_path, true);
            sw.WriteLine("Площадь={0}", this.Square(this._radius));
            sw.Close();

        }
        public void informer_console()
        {
            Console.WriteLine("Площадь окружности больше 100");
        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            var myCirule = new Circle();
            Mydeliegat _delegate = myCirule.Print_square;    
            myCirule.Printname();
            myCirule._radius = 3f;
            myCirule.name = "Круг";
            myCirule.Printname();
            /* myCirule.Print_square();
             myCirule.Print_square(true);*/
            _delegate?.Invoke();
            _delegate += myCirule.Write_square;
            _delegate?.Invoke();
            _delegate -= myCirule.Write_square;
            _delegate?.Invoke();
            _delegate -= myCirule.Print_square;
            _delegate?.Invoke();
        }

    }

}
