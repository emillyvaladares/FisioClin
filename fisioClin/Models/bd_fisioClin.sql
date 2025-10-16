create database FisioClin;
use FisioClin;

create table Paciente (
id_paciente int not null primary key auto_increment,
nome_pac varchar (200),
cpf_pac varchar (15),
cep_pac varchar (20),
rg_pac varchar (20),
bairro_pac varchar (200),
data_nascmento_pac date,
rua_pac varchar (200),
numero_pac varchar (100),
sexo_pac varchar (10),
email_pac varchar (200),
telefone_pac varchar (20)
);

insert into Paciente values (1,'emilly', '060.042.332-21', '789598', '375723',
 'bairro parque São Pedro', '2007-05-31', 'Rua Tupã', '145', 'feminino', 
 'valadaresemillylavinia@gmail.com', '69 99275-1820');
 
create table Laudo (
id_laudo int not null primary key auto_increment,
Validade_laudo varchar (200),
Tipo_Exame varchar (200),
diagnostico_laudo varchar (200),
observacao_laudo varchar (200),
status_laudo varchar (200),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente)
);

insert into Laudo Values (1, 'Valido por 1 ano', 'Queropraxia', 'Escoliose', 'Paciente sente muitas dores',
'Em aberto',1);

create table Cargo (
id_cargo int not null primary key auto_increment,
nome_cargo varchar (200),
departamento_cargo varchar (200),
descricao_cargo varchar (200),
carga_horaria int,
data_criacao date,
data_atualizacao date,
observacoes_cargo varchar (200)
);

insert into Cargo values (1, 'Queroprata', 'Fisioterapia',
 'Realiza trabalho com pessoas com problema nas articulações.', 8, '2018-07-15', '2023-04-26',
 'Importante');

create table Funcionarios (
id_funcionario int not null primary key auto_increment,
nome_func varchar (200),
cpf_func varchar (15),
tipo_vinculo varchar (200),
senha_func varchar (200),
rg_func varchar (20),
especialidade_func varchar (200),
subespecialidade_func varchar (200),
telefone_pac varchar (20),
email_func varchar (200),
registro_profissional_func varchar (200),
certificados_func varchar (200),
data_nascmento_func date,
data_contratacao_func date
);

Insert into Funcionarios values (1, 'Renata Chagas', '032.854.754-44', 'clt',
'emilly123', '737564', 'Queropatra', 'Pediatra', '69 99535-3466', 'jhdsfbsdj@gmail.com'
, '35734', 'Curso De Queropraxia', '2000-08-23', '2024-05-27');

create table Sala (
id_sala int not null primary key auto_increment,
nome_sala varchar (200),
numero_sala varchar (200),
capacidade_sala varchar (200),
tipo_sala varchar (200),
disponibilidade_sala varchar (50),
observacao_sala varchar (200)
);

insert into Sala values (1, 'Sala de Massagem', '23', '50 pessoas', 'Sala para relaxamento',
'Ocupada', 'Sala com equipamentos para a realização de massagens.');

create table Sessao (
id_sessao int not null primary key auto_increment,
data_sessao date,
horario_sessao time,
tipo_sessao varchar (200),
observacao_sessao varchar (200),
id_funcionario_fk int not null,
foreign key (id_funcionario_fk) references Funcionarios(id_funcionario),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente)
);

insert into Sessao values (1, '2025-12-05', '10:00', 'Sessao Ortopédica',
 'sessao para paciente compé torcido', 1, 1);

create table Agenda (
id_agenda int not null primary key auto_increment,
data_ag date,
horario_ag time,
id_sala_fk int not null,
foreign key (id_sala_fk) references sala(id_sala),
id_funcionario_fk int not null,
foreign key (id_funcionario_fk) references Funcionarios(id_funcionario),
id_sessao_fk int not null,
foreign key (id_sessao_fk) references Sessao(id_sessao),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente),
observacao_ag varchar (200)
);

Insert into Agenda values (1, '2025-10-23', '09:00', 1, 1, 1, 1, 'Agenda do dia 23');

create table Prontuario (
id_prontuario int not null primary key auto_increment,
data_pront date,
alergia_pront varchar (200),
comorbidade_pront varchar (200),
doenca_previa_pront varchar (200),
historico_familiar_pront varchar (200),
habito_vida_pront varchar (200),
avaliacao_pront varchar(200),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente)
);

iNSERT Into Prontuario values (1, '2025-03-28', 'dipirona', null, null, 
'diabetes', 'Caminhadas', 'Péssimo estado', 1); 

create table Pagamento (
id_pagamento int not null primary key auto_increment,
data_pagamento date,
numero_parcelas int,
valor_pagamento float,
forma_pagamento varchar (200),
status_pagamento varchar (200),
observacao_pagamento varchar (200),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente)
);

Insert into Pagamento values (1, '2025-09-15', 5, 170, 'crédito', 'Em processo, duas parcelas pagas',
'Paciente tem pago corretamente', 1);

create table financeiro ( 
id_financeiro int not null primary key auto_increment,
periodo_fin float,
id_funcionario_fk int not null,
foreign key (id_funcionario_fk) references Funcionarios(id_funcionario)
);

Insert into Financeiro values (1, 12, 1);

create table Login (
id_login int not null auto_increment,
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente),
id_funcionario_fk int not null,
foreign key (id_funcionario_fk) references Funcionarios(id_funcionario)
);