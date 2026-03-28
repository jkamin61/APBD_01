using ConsoleApp1.service.equipment;
using ConsoleApp1.service.report;
using ConsoleApp1.service.rental;
using ConsoleApp1.service.user;

IUserService userService = new UserService();
IEquipmentService equipmentService = new EquipmentService();
IRentalService rentalService = new RentalService(userService, equipmentService);
IReportService reportService = new ReportService(equipmentService, rentalService);

var laptop = equipmentService.AddLaptop("Dell Latitude", 16, "Intel i7");
var camera = equipmentService.AddCamera("Canon EOS", 24, "Wide");
var projector = equipmentService.AddProjector("Epson X1", 3200, "FullHD");

var student = userService.AddStudent("Jan", "Kowalski", "s12345");
var employee = userService.AddEmployee("Anna", "Nowak", "IT");

var rental1 = rentalService.RentEquipment(student.Id, laptop.Id, 7);
Console.WriteLine("Correct rental:");
Console.WriteLine(rental1);

try
{
    rentalService.RentEquipment(student.Id, laptop.Id, 5);
}
catch (Exception ex)
{
    Console.WriteLine("Expected error:");
    Console.WriteLine(ex.Message);
}

rentalService.ReturnEquipment(rental1.Id, DateTime.Now.AddDays(3));

var rental2 = rentalService.RentEquipment(employee.Id, camera.Id, 2);
rentalService.ReturnEquipment(rental2.Id, DateTime.Now.AddDays(5));

var report = reportService.GenerateSummary();
Console.WriteLine($"Total equipment: {report.TotalEquipment}");
Console.WriteLine($"Available: {report.AvailableEquipment}");
Console.WriteLine($"Rented: {report.RentedEquipment}");
Console.WriteLine($"Broken: {report.BrokenEquipment}");
Console.WriteLine($"In service: {report.InServiceEquipment}");
Console.WriteLine($"Active rentals: {report.ActiveRentals}");
Console.WriteLine($"Overdue rentals: {report.OverdueRentals}");