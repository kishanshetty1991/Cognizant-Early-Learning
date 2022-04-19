1. Create table with Foreign Key constraint

create table orders(
ord_no numeric(5) primary key,
purch_amt decimal(8,2),
ord_date date,
customer_id numeric(5),
salesman_id numeric(5) constraint ct foreign key(salesman_id)
references salesman(salesman_id));
go
---------------------------------------------------------

2. Alter Supplier table with Check Constraint

alter table Supplier
add constraint ct
check(len(contact)=10);
go
---------------------------------------------------------

3.Worker and Admin Departments

select a.deptname as "Worker Department",
a.location as Location,
b.deptname as "Manager Department"
from department a join department b
on a.admrdept=b.deptno and
a.admrdept!=a.deptno
order by a.deptname;
go
------------------------------------------------------------

4. Employee with reporting manger

select concat(a.lastname," works for ", b.lastname) as Hierarchy
from
 (select e.lastname,e.empno,e.job,d.mgrno 
 from employee e 
 join department d on e.workdept=
 d.deptno) as a join 
 (select 
  e.lastname,e.empno,e.job,d.mgrno 
  from employee e 
  join department d on e.workdept=
  d.deptno) as b 
  on a.mgrno=b.empno
  where a.mgrno!=a.empno 
  order by a.lastname;
go
------------------------------------------------------------

5.Procedure to display the Employees of a specific Department
  
create proc EmployeesDept(@DeptNo
varchar) as
begin
select lastname as Name from
employee 
where workdept='D21'
end
go
-----------------------------------------------------------

6. Procedure to display all the Departments

create proc AvailableDepartments as 
begin
 select deptname as Name from
 department
end 
go
---------------------------------------------------------

7.Employees working in New York

select e.firstname,e.lastname,e.salary from employee e join department d on
e.workdept=d.deptno
where d.location="New York"
order by e.firstname;
go

----------------------------------------------------------
8.Employee Count per Department

create proc EmployeeCount(@deptno varchar, @total_employees int output) as
begin
select @total_employees = count(*) from employee where workdept = 'D21';
end
go

-------------------------------------------------------------







