create database FisioClin;
use FisioClin;

create table Endereco (
id_end int primary key auto_increment,
cep_end varchar (20),
bairro_end varchar (200),
rua_end varchar (200),
numero_end varchar (100)
);

create table Paciente (
id_paciente int primary key auto_increment,
nome_pac varchar (200),
cpf_pac varchar (15),
rg_pac varchar (20),
data_nascmento_pac date,
sexo_pac varchar (10),
email_pac varchar (200),
telefone_pac varchar (20),
id_end_fk  int not null, 
foreign key (id_end_fk) references endereco(id_end)
);

create table Laudo (
id_laudo int primary key auto_increment,
tipo_exame varchar (200),
diagnostico_laudo varchar (200),
observacao_laudo varchar (200),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente)
);

create table Funcionarios (
id_funcionario int primary key auto_increment,
nome_func varchar (200),
cpf_func varchar (15),
rg_func varchar (20),
email_func varchar (200),
data_nascmento_func date,
cargo_func varchar (200),
especialidade_func varchar(200),
registro_profissional_func varchar (200),
data_contratacao_func date,
tipo_vinculo_func varchar (200),
certificados_func varchar (200),
telefone_pac varchar (20),
senha_func varchar (200)
);

alter table Funcionario drop cargo_func;

create table Cargo (
id_cargo int primary key auto_increment,
nome_cargo varchar (200),
departamento_cargo varchar (200),
descricao_cargo varchar (200),
carga_horaria int,
data_criacao date,
data_atualizacao date,
observacoes_cargo varchar (200)
);

create table cargo_funcionario (
id_cargo_funcionario int primary key auto_increment,
id_cargo_fk int not null,
id_funcionario_fk int not null,
foreign key (id_cargo_fk) references Cargo(id_cargo),
foreign key (id_funcionario_fk) references Funcionarios(id_funcionario)
);

create table Sala (
id_sala int primary key auto_increment,
numero_sala varchar (200),
tipo_sala varchar (200),
observacao_sala varchar (200),
capacidade_sala varchar (200),
disponibilidade_sala varchar (50)
);

create table Sessao (
id_sessao int primary key auto_increment,
data_sessao date,
horario_sessao time,
tipo_sessao varchar (200),
observacao_sessao varchar (200),
id_funcionario_fk int not null,
foreign key (id_funcionario_fk) references Funcionarios(id_funcionario),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente)
);

create table Agenda (
id_agenda int primary key auto_increment,
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

create table Prontuario (
id_prontuario int primary key auto_increment,
data_pront date,
alergia_pront varchar (200),
comorbidade_pront varchar (200),
doenca_previa_pront varchar (200),
historico_familiar_pront varchar (200),
habito_vida_pront varchar (200),
avaliacao_pront varchar(200),
status_pront varchar(200),
id_paciente_fk int not null,
foreign key (id_paciente_fk) references Paciente(id_paciente)
);

create table Pagamento (
id_pagamento int primary key auto_increment,
data_pagamento date,
numero_parcelas int,
valor_pagamento float,
forma_pagamento varchar (200),
status_pagamento varchar (200),
observacao_pagamento varchar (200)
);

create table financeiro ( 
id_financeiro int primary key auto_increment,
periodo_fin float,
id_funcionario_fk int not null,
foreign key (id_funcionario_fk) references Funcionarios(id_funcionario)
);