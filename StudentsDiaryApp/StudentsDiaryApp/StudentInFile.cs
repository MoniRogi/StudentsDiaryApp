
namespace StudentsDiaryApp
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "grades.txt";

        private string fullFileName;

        public override event GradeAddedDelegate GradeAdded;

        public StudentInFile(string name, string surname, string sex)
            : base(name, surname, sex)
        {
            fullFileName = $"{name}_{surname}_{sex}";
        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 6)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
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
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(gradeAsFloat);
            }
        }
        public override void AddGrade(int grade)
        {
            float gradeAsFloat = (float)grade;
            using var writer = File.AppendText(fileName);
            writer.WriteLine(gradeAsFloat);
        }
        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out _))
            {
                using var writer = File.AppendText(fileName);
                writer.WriteLine(grade);
                AddGrade(float.Parse(grade.ToString()));

                switch (grade)
                {
                    case "6":
                        this.AddGrade(6);
                        break;
                    case "6+":
                    case "-6":
                        this.AddGrade((float)5.75);
                        break;
                    case "5+":
                    case "+5":
                        this.AddGrade((float)5.5);
                        break;
                    case "5":
                        this.AddGrade(5);
                        break;
                    case "5-":
                    case "-5":
                        this.AddGrade((float)4.75);
                        break;
                    case "4+":
                    case "+4":
                        this.AddGrade((float)4.5);
                        break;
                    case "4":
                        this.AddGrade(4);
                        break;
                    case "4-":
                    case "-4":
                        this.AddGrade((float)3.75);
                        break;
                    case "3+":
                    case "+3":
                        this.AddGrade((float)3.5);
                        break;
                    case "3":
                        this.AddGrade(3);
                        break;
                    case "-3":
                    case "3-":
                        this.AddGrade((float)2.75);
                        break;
                    case "2+":
                    case "+2":
                        this.AddGrade((float)2.5);
                        break;
                    case "2":
                        this.AddGrade(2);
                        break;
                    case "2-":
                    case "-2":
                        this.AddGrade((float)1.75);
                        break;
                    case "1+":
                    case "+1":
                        this.AddGrade((float)1.5);
                        break;
                    case "1":
                        this.AddGrade(1);
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
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.GetStatistics(gradesFromFile);
            return result;
        }


        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists($"{fileName}"))
            {
                using var reader = File.OpenText($"{fileName}");
                var line = reader.ReadLine();
                while (line != null)
                {
                    var grade = float.Parse(line);
                    grades.Add(grade);
                    line = reader.ReadLine();
                }
            }
            return grades;
        }

        private Statistics GetStatistics(List<float> grades)
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
