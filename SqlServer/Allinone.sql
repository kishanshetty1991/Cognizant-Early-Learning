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

9.Trigger - claims

CREATE TRIGGER claim_audits on claims 
for insert
as
begin
    declare @custname varchar(25);
    declare @oamount int;
    declare @lamount int;
    declare @amount varchar(25);
    declare @action varchar(25);
    
    select @custname = first_name from Inserted I 
    inner join customer_policy CP on CP.id = I.customer_policy_id
    inner join customer C on C.id = CP.customer_id;
    
    select @oamount = amount_of_claim from claims where customer_policy_id=101 order by amount_of_claim desc;
    select @lamount = i.amount_of_claim from inserted i;
    select @amount = @lamount + @lamount + 50000;
   
    
    insert into claim_audit values(@custname , @amount , 'Updated customer claimed amount');
    -- select * from claim_audit; 
end
go
-----------------------------------------------------
10.Department records using cursors

Declare @dept_name varchar(max), @empcount varchar(max);

Declare dpt_cur cursor FOR
select count(e.workdept), d.deptname
from Department d join Employee e
on d.deptno = e.workdept
group by e.workdept,d.deptname
order by d.deptname;
open dpt_cur;

fetch next from dpt_cur into
@empcount,
@dept_name;
while @@fetch_status = 0

Begin
    if(@empcount > 1)
    print @dept_name+"department has"+cast(@empcount as varchar)+"employees";
    fetch next from dpt_cur into
    @empcount,
    @dept_name;
end;
close dpt_cur;
deallocate dpt_cur;
go
----------------------------------------------------------------------------------
11.Create a Procedure delete_status

create procedure delete_status
@status_id int
as 
begin
        if exists(select * from agent where id = @status_id)
        begin
                insert into status_error_log(error_msg)
                values('child records existing in claims table');
        end

        else if exists(select * from address where id = @status_id)
        begin
                insert into status_error_log(error_msg)
                values('child records existing in claims table');
        end

        else if exists(select * from insurance_company where id = @status_id)
        begin
                insert into status_error_log(error_msg)
                values('child records existing in claims table');
        end

        else if exists(select * from customer where id = @status_id)
        begin
                insert into status_error_log(error_msg)
                values('child records existing in claims table');
        end

        else if exists(select * from customer_policy where id = @status_id)
        begin
                insert into status_error_log(error_msg)
                values('child records existing in claims table');
        end

        else if exists(select * from policy where id = @status_id)
        begin
                insert into status_error_log(error_msg)
                values('child records existing in claims table');
        end

        else if exists(select * from claims where id = @status_id)
        begin
                insert into status_error_log(error_msg) values("child records existing in claims table");
        end

        else
        begin
                delete from status where id = @status_id
        end
end
go




