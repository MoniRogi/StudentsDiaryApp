
namespace StudentsDiaryApp
{
    public class StudentInMemory : StudentBase
    {
        public override event GradeAddedDelegate GradeAdded;

        private List<float> grades = new List<float>();
        public StudentInMemory(string name, string surname, string sex)
            : base(name, surname, sex)
        {
        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 6)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość oceny.");
            }
        }
        public override void AddGrade(double grade)
        {
            float gradeAsFloat = (float)grade;
            this.AddGrade(gradeAsFloat);
        }
        public override void AddGrade(int grade)
        {
            float gradeAsFloat = grade;
            this.AddGrade(gradeAsFloat);
        }
        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);

                switch (grade)
                {
                    case "6":
                        this.grades.Add(6);
                        break;
                    case "6+":
                    case "-6":
                        this.grades.Add((float)5.75);
                        break;
                    case "5+":
                    case "+5":
                        this.grades.Add((float)5.5);
                        break;
                    case "5":
                        this.grades.Add(5);
                        break;
                    case "5-":
                    case "-5":
                        this.grades.Add((float)4.75);
                        break;
                    case "4+":
                    case "+4":
                        this.grades.Add((float)4.5);
                        break;
                    case "4":
                        this.grades.Add(4);
                        break;
                    case "4-":
                    case "-4":
                        this.grades.Add((float)3.75);
                        break;
                    case "3+":
                    case "+3":
                        this.grades.Add((float)3.5);
                        break;
                    case "3":
                        this.grades.Add(3);
                        break;
                    case "-3":
                    case "3-":
                        this.grades.Add((float)2.75);
                        break;
                    case "2+":
                    case "+2":
                        this.grades.Add((float)2.5);
                        break;
                    case "2":
                        this.grades.Add(2);
                        break;
                    case "2-":
                    case "-2":
                        this.grades.Add((float)1.75);
                        break;
                    case "1+":
                    case "+1":
                        this.grades.Add((float)1.5);
                        break;
                    case "1":
                        this.grades.Add(1);
                        break;
                    default:
                        throw new Exception("Zła ocena (wpisz 1-6)");
                }
            }
            else
            {
                throw new Exception("To słowo nie jest liczbą.");
            }

        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grades)
            {

                statistics.AddGrade(grade);
            }
            return statistics;
        }

    }
}