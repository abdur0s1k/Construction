using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using YourProjectNamespace.Models;


namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext()) // Здесь используйте ваш контекст
            {
                // Загружаем данные для каждой таблицы
                dataGridView1.DataSource = context.Departments.ToList();
                dataGridView2.DataSource = context.Employees.ToList();
                dataGridView3.DataSource = context.Organizations.ToList();
                dataGridView4.DataSource = context.Contracts.ToList();
                dataGridView5.DataSource = context.ProjectWorks.ToList();
            }
        }



        // Обработчик для добавления строки в таблицу
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string choice = Microsoft.VisualBasic.Interaction.InputBox(
                "Куда вы хотите добавить запись?\n\nВведите: \n1 — Отдел\n2 — Сотрудника\n3 — Организацию\n4 — Договор\n5 — Проектную работу",
            "Добавление",
                "1");

            using (var context = new AppDbContext())
            {
                if (choice == "1")
                {
                    // Добавление записи в таблицу Departments
                    var department = new Department
                    {
                        DepartmentName = "New Department",
                        Floor = 1,
                        Phone = "123456789",
                        DepartmentHead = "John Doe"
                    };
                    context.Departments.Add(department);
                    context.SaveChanges(); // Сохраняем изменения в базе
                    MessageBox.Show("Отдел добавлен.");
                }
                else if (choice == "2")
                {
                    var department = context.Departments.FirstOrDefault();
                    if (department == null)
                    {
                        MessageBox.Show("В базе данных нет отделов.");
                        return;
                    }

                    var employee = new Employee
                    {
                        FullName = "New Employee",
                        Position = "Manager",
                        DepartmentID = department.DepartmentID, // используем ID существующего отдела
                        Gender = "M",
                        Address = "123 Main St",
                        DateOfBirth = new DateTime(1990, 1, 1)
                    };

                    context.Employees.Add(employee);
                    context.SaveChanges(); // Сохраняем изменения в базе
                    MessageBox.Show("Сотрудник добавлен.");
                }

                else if (choice == "3")
                {
                    // Добавление записи в таблицу Organizations
                    var organization = new Organization
                    {
                        OrganizationName = "New Organization",
                        BusinessType = "IT",
                        Country = "USA",
                        City = "New York",
                        Address = "456 Business St",
                        DirectorFullName = "Jane Smith"
                    };
                    context.Organizations.Add(organization);
                    context.SaveChanges(); // Сохраняем изменения в базе
                    MessageBox.Show("Организация добавлена.");
                }
                else if (choice == "4")
                {
                    var organization = context.Organizations.FirstOrDefault();
                    if (organization == null)
                    {
                        MessageBox.Show("В базе данных нет организаций.");
                        return;
                    }

                    var contract = new YourProjectNamespace.Models.Contract
                    {
                        ContractNumber = "C-12345",
                        ContractDate = DateTime.Today,
                        OrganizationID = organization.OrganizationID, // используем ID найденной организации
                        ContractValue = 50000
                    };

                    context.Contracts.Add(contract);
                    context.SaveChanges(); // Сохраняем изменения в базе
                    MessageBox.Show("Договор добавлен.");
                }

                else if (choice == "5")
                {
                    // Добавление записи в таблицу ProjectWorks
                    var projectWork = new ProjectWork
                    {
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today.AddMonths(6),
                        ContractID = 2, // Пример с ContractID = 1
                        DepartmentID = 2 // Пример с DepartmentID = 1
                    };
                    context.ProjectWorks.Add(projectWork);
                    context.SaveChanges(); // Сохраняем изменения в базе
                    MessageBox.Show("Проектная работа добавлена.");
                }
                else
                {
                    MessageBox.Show("Неверный выбор. Введите 1, 2, 3, 4 или 5.");
                }
            }
        }

        // Списки для хранения удалённых записей
        // Списки удаленных записей для отслеживания
        List<int> deletedDepartmentIds = new List<int>();
        List<int> deletedEmployeeIds = new List<int>();
        List<int> deletedOrganizationIds = new List<int>();
        List<int> deletedContractIds = new List<int>();
        List<int> deletedProjectWorkIds = new List<int>();

        // Обработчик для удаления строки
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string choice = Microsoft.VisualBasic.Interaction.InputBox(
                "Что вы хотите удалить?\n\nВведите: \n1 — Отдел\n2 — Сотрудника\n3 — Организацию\n4 — Договор\n5 — Проектную работу",
                "Удаление",
                "1");

            using (var context = new AppDbContext()) // Используем контекст Entity Framework
            {
                if (choice == "1" && dataGridView1.SelectedRows.Count > 0)
                {
                    var row = dataGridView1.SelectedRows[0];
                    if (row.Cells["DepartmentID"].Value != null)
                    {
                        int departmentId = Convert.ToInt32(row.Cells["DepartmentID"].Value);

                        // Получаем отдел с его связанными сущностями
                        var department = context.Departments
                                                .Include(d => d.Employees)
                                                .Include(d => d.ProjectWorks)
                                                .FirstOrDefault(d => d.DepartmentID == departmentId);

                        if (department != null)
                        {
                            if ((department.Employees?.Any() ?? false) || (department.ProjectWorks?.Any() ?? false))
                            {
                                MessageBox.Show(
                                    "Невозможно удалить отдел, пока существуют связанные сотрудники или проектные работы.",
                                    "Ошибка удаления",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return;
                            }

                            context.Departments.Remove(department);
                            context.SaveChanges();
                            MessageBox.Show("Отдел удалён.");

                            // Обновляем DataGridView после удаления
                            dataGridView1.DataSource = context.Departments.ToList();
                        }
                    }
                }

                else if (choice == "2" && dataGridView2.SelectedRows.Count > 0)
                {
                    var row = dataGridView2.SelectedRows[0];
                    if (row.Cells["EmployeeID"].Value != null)
                    {
                        int employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);

                        var employee = context.Employees.Find(employeeId);

                        if (employee != null)
                        {
                            context.Employees.Remove(employee);
                            context.SaveChanges();
                            MessageBox.Show("Сотрудник удалён.");

                            // Обновляем источник данных после удаления
                            dataGridView2.DataSource = context.Employees.ToList();
                        }
                    }
                }


                else if (choice == "3" && dataGridView3.SelectedRows.Count > 0)
                {
                    var row = dataGridView3.SelectedRows[0];
                    if (row.Cells["OrganizationID"].Value != null)
                    {
                        int organizationId = Convert.ToInt32(row.Cells["OrganizationID"].Value);

                        var organization = context.Organizations
                                                   .Include(o => o.Contracts) // Загружаем связанные контракты
                                                   .FirstOrDefault(o => o.OrganizationID == organizationId);

                        if (organization != null)
                        {
                            // Проверяем наличие связанных записей
                            if (organization.Contracts != null && organization.Contracts.Any())
                            {
                                MessageBox.Show("Невозможно удалить организацию, пока существуют связанные договоры.\nСначала удалите договоры.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Удаляем
                            context.Organizations.Remove(organization);
                            context.SaveChanges();
                            MessageBox.Show("Организация удалена.");

                            dataGridView1.DataSource = context.Departments.ToList();
                        }
                    }
                }

                else if (choice == "4" && dataGridView4.SelectedRows.Count > 0)
                {
                    var row = dataGridView4.SelectedRows[0];
                    if (row.Cells["ContractID"].Value != null)
                    {
                        int contractId = Convert.ToInt32(row.Cells["ContractID"].Value);
                        deletedContractIds.Add(contractId);

                        // Получаем сущность по ID и удаляем её
                        var contract = context.Contracts.Find(contractId);
                        if (contract != null)
                        {
                            context.Contracts.Remove(contract);
                            context.SaveChanges(); // Сохраняем изменения в базе данных
                            MessageBox.Show("Договор удален.");
                        }

                        dataGridView1.DataSource = context.Departments.ToList();
                    }
                }
                else if (choice == "5" && dataGridView5.SelectedRows.Count > 0)
                {
                    var row = dataGridView5.SelectedRows[0];
                    if (row.Cells["ProjectWorkID"].Value != null)
                    {
                        int projectWorkId = Convert.ToInt32(row.Cells["ProjectWorkID"].Value);

                        var projectWork = context.ProjectWorks.Find(projectWorkId);

                        if (projectWork != null)
                        {
                            context.ProjectWorks.Remove(projectWork);
                            context.SaveChanges();
                            MessageBox.Show("Проектная работа удалена.");

                            // Обновляем источник данных для DataGridView после удаления
                            dataGridView5.DataSource = context.ProjectWorks.ToList();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Неверный выбор или не выбрана строка.");
                }
            }
        }
        // Обработчик для редактирования строки
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AppDbContext()) // Контекст Entity Framework
                {
                    // Начинаем транзакцию
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // Сохраняем изменения для каждого DataGridView (для каждой таблицы)

                            // Сохраняем изменения для Departments
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue; // Пропускаем строку, если она новая

                                var departmentId = Convert.ToInt32(row.Cells["DepartmentID"].Value);
                                var departmentName = row.Cells["DepartmentName"].Value?.ToString();
                                var floor = Convert.ToInt32(row.Cells["Floor"].Value);
                                var phone = row.Cells["Phone"].Value?.ToString();
                                var departmentHead = row.Cells["DepartmentHead"].Value?.ToString();

                                var department = context.Departments.Find(departmentId);
                                if (department != null)
                                {
                                    // Обновляем существующую запись
                                    department.DepartmentName = departmentName;
                                    department.Floor = floor;
                                    department.Phone = phone;
                                    department.DepartmentHead = departmentHead;
                                }
                                else
                                {
                                    // Если записи нет, добавляем новую
                                    var newDepartment = new Department
                                    {
                                        DepartmentID = departmentId,
                                        DepartmentName = departmentName,
                                        Floor = floor,
                                        Phone = phone,
                                        DepartmentHead = departmentHead
                                    };
                                    context.Departments.Add(newDepartment);
                                }
                            }

                            // Сохраняем изменения для Employees
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                                var fullName = row.Cells["FullName"].Value?.ToString();
                                var position = row.Cells["Position"].Value?.ToString();
                                var departmentId = Convert.ToInt32(row.Cells["DepartmentID"].Value);

                                var employee = context.Employees.Find(employeeId);
                                if (employee != null)
                                {
                                    // Обновляем существующую запись
                                    employee.FullName = fullName;
                                    employee.Position = position;
                                    employee.DepartmentID = departmentId;
                                }
                                else
                                {
                                    // Если записи нет, добавляем новую
                                    var newEmployee = new Employee
                                    {
                                        EmployeeID = employeeId,
                                        FullName = fullName,
                                        Position = position,
                                        DepartmentID = departmentId
                                    };
                                    context.Employees.Add(newEmployee);
                                }
                            }

                            // Сохраняем изменения для Organizations
                            foreach (DataGridViewRow row in dataGridView3.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var organizationId = Convert.ToInt32(row.Cells["OrganizationID"].Value);
                                var organizationName = row.Cells["OrganizationName"].Value?.ToString();
                                var businessType = row.Cells["BusinessType"].Value?.ToString();
                                var country = row.Cells["Country"].Value?.ToString();
                                var city = row.Cells["City"].Value?.ToString();
                                var address = row.Cells["Address"].Value?.ToString();
                                var directorFullName = row.Cells["DirectorFullName"].Value?.ToString();

                                var organization = context.Organizations.Find(organizationId);
                                if (organization != null)
                                {
                                    // Обновляем существующую запись
                                    organization.OrganizationName = organizationName;
                                    organization.BusinessType = businessType;
                                    organization.Country = country;
                                    organization.City = city;
                                    organization.Address = address;
                                    organization.DirectorFullName = directorFullName;
                                }
                                else
                                {
                                    // Если записи нет, добавляем новую
                                    var newOrganization = new Organization
                                    {
                                        OrganizationID = organizationId,
                                        OrganizationName = organizationName,
                                        BusinessType = businessType,
                                        Country = country,
                                        City = city,
                                        Address = address,
                                        DirectorFullName = directorFullName
                                    };
                                    context.Organizations.Add(newOrganization);
                                }
                            }

                            // Сохраняем изменения для Contracts
                            foreach (DataGridViewRow row in dataGridView4.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var contractId = Convert.ToInt32(row.Cells["ContractID"].Value);
                                var contractNumber = row.Cells["ContractNumber"].Value?.ToString();
                                var contractDate = Convert.ToDateTime(row.Cells["ContractDate"].Value);
                                var organizationId = Convert.ToInt32(row.Cells["OrganizationID"].Value);
                                var contractValue = Convert.ToDecimal(row.Cells["ContractValue"].Value);

                                var contract = context.Contracts.Find(contractId);
                                if (contract != null)
                                {
                                    // Обновляем существующую запись
                                    contract.ContractNumber = contractNumber;
                                    contract.ContractDate = contractDate;
                                    contract.OrganizationID = organizationId;
                                    contract.ContractValue = contractValue;
                                }
                                else
                                {
                                    // Если записи нет, добавляем новую
                                    var newContract = new YourProjectNamespace.Models.Contract
                                    {
                                        ContractID = contractId,
                                        ContractNumber = contractNumber,
                                        ContractDate = contractDate,
                                        OrganizationID = organizationId,
                                        ContractValue = contractValue
                                    };
                                    context.Contracts.Add(newContract);
                                }
                            }

                            // Сохраняем изменения для ProjectWorks
                            foreach (DataGridViewRow row in dataGridView5.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var projectWorkId = Convert.ToInt32(row.Cells["ProjectWorkID"].Value);
                                var startDate = Convert.ToDateTime(row.Cells["StartDate"].Value);
                                var endDate = Convert.ToDateTime(row.Cells["EndDate"].Value);
                                var contractId = Convert.ToInt32(row.Cells["ContractID"].Value);
                                var departmentId = Convert.ToInt32(row.Cells["DepartmentID"].Value);

                                var projectWork = context.ProjectWorks.Find(projectWorkId);
                                if (projectWork != null)
                                {
                                    // Обновляем существующую запись
                                    projectWork.StartDate = startDate;
                                    projectWork.EndDate = endDate;
                                    projectWork.ContractID = contractId;
                                    projectWork.DepartmentID = departmentId;
                                }
                                else
                                {
                                    // Если записи нет, добавляем новую
                                    var newProjectWork = new ProjectWork
                                    {
                                        ProjectWorkID = projectWorkId,
                                        StartDate = startDate,
                                        EndDate = endDate,
                                        ContractID = contractId,
                                        DepartmentID = departmentId
                                    };
                                    context.ProjectWorks.Add(newProjectWork);
                                }
                            }

                            // Сохраняем изменения в базе данных
                            context.SaveChanges();

                            // Подтверждаем транзакцию
                            transaction.Commit();
                            MessageBox.Show("Данные успешно сохранены.");
                        }
                        catch (Exception ex)
                        {
                            // Откатываем транзакцию в случае ошибки
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Пожалуйста, введите значение для поиска.");
                return;
            }

            // Запрашиваем, в какой таблице искать
            string choice = Microsoft.VisualBasic.Interaction.InputBox(
                "В какой таблице вы хотите искать?\n\nВведите: \n1 — Отделы\n2 — Сотрудники\n3 — Организации\n4 — Договоры\n5 — Проектные работы",
                "Выбор таблицы для поиска",
                "1");

            using (var context = new AppDbContext())
            {
                switch (choice)
                {
                    case "1":
                        await SearchDepartmentsAsync(context, searchTerm);
                        break;

                    case "2":
                        await SearchEmployeesAsync(context, searchTerm);
                        break;

                    case "3":
                        await SearchOrganizationsAsync(context, searchTerm);
                        break;

                    case "4":
                        await SearchContractsAsync(context, searchTerm);
                        break;

                    case "5":
                        await SearchProjectWorksAsync(context, searchTerm);
                        break;

                    default:
                        MessageBox.Show("Неверный выбор. Введите 1, 2, 3, 4 или 5.");
                        break;
                }
            }
        }

        private async Task SearchDepartmentsAsync(AppDbContext context, string searchTerm)
        {
            var departments = await context.Departments
                .Where(d => d.DepartmentName.Contains(searchTerm))
                .ToListAsync();

            dataGridView1.DataSource = departments; // Отображаем результаты в таблице Departments
        }

        private async Task SearchEmployeesAsync(AppDbContext context, string searchTerm)
        {
            var employees = await context.Employees
                .Where(e => e.FullName.Contains(searchTerm) || e.Position.Contains(searchTerm))
                .ToListAsync();

            dataGridView2.DataSource = employees; // Отображаем результаты в таблице Employees
        }

        private async Task SearchOrganizationsAsync(AppDbContext context, string searchTerm)
        {
            var organizations = await context.Organizations
                .Where(o => o.OrganizationName.Contains(searchTerm))
                .ToListAsync();

            dataGridView3.DataSource = organizations; // Отображаем результаты в таблице Organizations
        }

        private async Task SearchContractsAsync(AppDbContext context, string searchTerm)
        {
            // Проверяем, является ли поисковый запрос числом (для поиска по ContractID)
            if (int.TryParse(searchTerm, out int contractId))
            {
                var contracts = await context.Contracts
                    .Where(c => c.ContractID == contractId)
                    .ToListAsync();

                dataGridView4.DataSource = contracts; // Отображаем результаты в таблице Contracts
            }
            else
            {
                var contracts = await context.Contracts
                    .Where(c => c.ContractNumber.Contains(searchTerm))
                    .ToListAsync();

                dataGridView4.DataSource = contracts; // Отображаем результаты в таблице Contracts
            }
        }

        private async Task SearchProjectWorksAsync(AppDbContext context, string searchTerm)
        {
            // Проверяем, является ли поисковый запрос числом (для поиска по ProjectWorkID)
            if (int.TryParse(searchTerm, out int projectWorkId))
            {
                var projectWorks = await context.ProjectWorks
                    .Where(p => p.ProjectWorkID == projectWorkId)
                    .ToListAsync();

                dataGridView5.DataSource = projectWorks; // Отображаем результаты в таблице ProjectWorks
            }
            else
            {
                var projectWorks = await context.ProjectWorks
                    .Where(p => p.ContractID.ToString().Contains(searchTerm) || p.DepartmentID.ToString().Contains(searchTerm))
                    .ToListAsync();

                dataGridView5.DataSource = projectWorks; // Отображаем результаты в таблице ProjectWorks
            }
        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
