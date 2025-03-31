//namespace SOLIDPrinciple
//{
//    // -------------------- SRP: Separate Responsibilities -------------------- //
//    // Course Model
//    public class Course
//    {
//        public int Id { get; set; }
//        public string Title { get; set; } = string.Empty;
//        public string Type { get; set; } = string.Empty;
//    }

//    // Course Management Service
//    public interface ICourseRepository
//    {
//        void AddCourse(Course course);
//        Course GetCourse(int id);
//    }

//    public class CourseRepository : ICourseRepository
//    {
//        private readonly Dictionary<int, Course> _courses = new Dictionary<int, Course>();

//        public void AddCourse(Course course)
//        {
//            _courses[course.Id] = course;
//            Console.WriteLine($"Course '{course.Title}' added.");
//        }

//        public Course GetCourse(int id)
//        {
//            return _courses.ContainsKey(id) ? _courses[id] : null;
//        }
//    }

//    // -------------------- OCP: Extend Functionality Without Modification -------------------- //
//    public interface ICourseType
//    {
//        void DeliverContent();
//    }

//    public class VideoCourse : ICourseType
//    {
//        public void DeliverContent()
//        {
//            Console.WriteLine("Delivering video course content.");
//        }
//    }

//    public class TextCourse : ICourseType
//    {
//        public void DeliverContent()
//        {
//            Console.WriteLine("Delivering text-based course content.");
//        }
//    }

//    public class LiveCourse : ICourseType
//    {
//        public void DeliverContent()
//        {
//            Console.WriteLine("Delivering live class session.");
//        }
//    }

//    // -------------------- LSP: Substitutable User Types -------------------- //
//    public abstract class EUser
//    {
//        public int Id { get; set; }
//        public string Name { get; set; } = string.Empty;
//    }

//    public class Student : EUser
//    {
//        public void EnrollCourse(Course course)
//        {
//            Console.WriteLine($"Student {Name} enrolled in {course.Title}.");
//        }
//    }

//    public class Instructor : EUser
//    {
//        public void CreateCourse(Course course, ICourseRepository courseRepository)
//        {
//            courseRepository.AddCourse(course);
//            Console.WriteLine($"Instructor {Name} created course {course.Title}.");
//        }
//    }

//    // -------------------- ISP: Interface Segregation -------------------- //
//    public interface IContentDelivery
//    {
//        void DeliverContent();
//    }

//    public interface IAssessment
//    {
//        void ConductAssessment();
//    }

//    public interface IGrading
//    {
//        void GradeStudent();
//    }

//    public class AssessmentService : IAssessment
//    {
//        public void ConductAssessment()
//        {
//            Console.WriteLine("Conducting assessment.");
//        }
//    }

//    public class GradingService : IGrading
//    {
//        public void GradeStudent()
//        {
//            Console.WriteLine("Grading student performance.");
//        }
//    }

//    // -------------------- DIP: Inject Dependencies -------------------- //
//    public interface INotificationService
//    {
//        void SendNotification(string message);
//    }

//    public class EmailNotificationService : INotificationService
//    {
//        public void SendNotification(string message)
//        {
//            Console.WriteLine("Email Notification: " + message);
//        }
//    }

//    //class LearningProgram
//    //{
//    //    static void Main()
//    //    {
//    //        ICourseRepository courseRepository = new CourseRepository();
//    //        INotificationService notificationService = new EmailNotificationService();

//    //        Instructor instructor = new Instructor { Id = 1, Name = "Dr. Smith" };
//    //        Student student = new Student { Id = 2, Name = "Alice" };

//    //        Course videoCourse = new Course { Id = 1, Title = "C# Basics", Type = "Video" };
//    //        instructor.CreateCourse(videoCourse, courseRepository);

//    //        student.EnrollCourse(videoCourse);

//    //        ICourseType videoDelivery = new VideoCourse();
//    //        videoDelivery.DeliverContent();

//    //        notificationService.SendNotification("New course available: C# Basics");
//    //    }
//    //}
//}
