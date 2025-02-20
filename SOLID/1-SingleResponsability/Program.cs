using SingleResponsability;

StudentRepository studentRepository = new StudentRepository();
ExportHelper exportHelper = new ExportHelper();
exportHelper.Export(studentRepository.GetAll());