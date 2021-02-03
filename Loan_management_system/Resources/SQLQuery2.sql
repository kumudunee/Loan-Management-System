create table loans(
loanid int Identity(1,1) ,
loanType Varchar(250) not null,
loanInterest varchar(250) primary key

);

select * from loans

create table customers(
cCode int  primary key,
cname varchar(250) not null,
dob varchar(250) not null,
age int not null,
gender varchar(50) not null,
address varchar(350) not null,
emailAddress varchar(350) not null,
mobile bigint not null,
civilStatus varchar(50) not null,
nationality varchar(250) not null,
id varchar(250) not null,
type varchar(250) not null,
loanInterest varchar(250) not null,
amount int not null,
duration int not null,
purpose varchar(350) not null,
starts varchar(250) not null,
ends varchar(250),
eds varchar(250) not null default 'NO',
job varchar(250) not null,
income int not null,
Caddress varchar(350),
Cmobile bigint ,
foreign key (loanInterest) references loans(loanInterest)
);

select * from customers

create table employee
(
eid int identity(1,1) primary key,
ename varchar(250) not null,
mobile bigint not null,
gender varchar(50) not null,
emailid varchar(150) not null,
username varchar(150) not null,
pass varchar(150) not null
);
 
 select * from employee






