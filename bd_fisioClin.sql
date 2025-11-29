create database fisioclin;
use fisioclin;

--------------------------------------------------------------------------------
-- TABELA PACIENTE
--------------------------------------------------------------------------------
#armazenda os dados do paciente
create table paciente (
    id_pac int not null auto_increment primary key,
    nome_pac varchar(200) not null,
    cpf_pac varchar(15),
    rg_pac varchar(20),
    data_nascimento_pac date,
    sexo_pac varchar(10),
    telefone_pac varchar(20),
    email_pac varchar(200),
    cep_pac varchar(20),
    rua_pac varchar(200),
    numero_pac varchar(20),
    bairro_pac varchar(200)
);
#SELECT *FROM paciente;

--------------------------------------------------------------------------------
-- TABELA CARGO
--------------------------------------------------------------------------------
#armazena os dados referente as funções de cada FUNCIONARIO
create table cargo (
    id_car int not null auto_increment primary key,
    nome_car varchar(200) not null,
    departamento_car varchar(200),
    descricao_car varchar(300),
    carga_horaria_car int,
    data_criacao_car date,
    data_atualizacao_car date,
    observacoes_car varchar(200)
);

--------------------------------------------------------------------------------
-- TABELA FUNCIONARIO
--------------------------------------------------------------------------------
#armazena os dados de cada funcionario
create table funcionario (
    id_fun int not null auto_increment primary key,
    nome_fun varchar(200) not null,
    cpf_fun varchar(14),
    rg_fun varchar(20),
    data_nascimento_fun date,
    telefone_fun varchar(20),
    email_fun varchar(200),
    tipo_vinculo_fun varchar(100),
    registro_profissional_fun varchar(200),
    especialidade_fun varchar(200),
    subespecialidade_fun varchar(200),
    certificados_fun varchar(200),
    data_contratacao_fun date,
    id_car_fk int null,
    foreign key (id_car_fk) references cargo(id_car) on delete set null
);

--------------------------------------------------------------------------------
-- TABELA SALA
--------------------------------------------------------------------------------
#armazena as informações de cada sala de atendimento
create table sala (
    id_sal int not null auto_increment primary key,
    nome_sal varchar(200) not null,
    numero_sal varchar(50),
    capacidade_sal int,
    tipo_sal varchar(200),
    disponibilidade_sal varchar(20) default 'disponivel',
    observacao_sal varchar(300)
);

# padronização do tipo da consulta
create table tipo(
	id_tip int auto_increment primary key,
    nome_tip varchar(200)
);
--------------------------------------------------------------------------------
-- TABELA AGENDA
--------------------------------------------------------------------------------
#dados de consultas agendadas, aqui vc verifica se ja existe naquele horario uma sala ou funcionario ocupado
create table agenda (
    id_age int not null auto_increment primary key,
    data_age date,
    horario_age time,    
    observacao_age varchar(200),
    id_sal_fk int null,
    id_fun_fk int null,
	id_pac_fk int null,
    id_tip_fk int null,
    foreign key (id_pac_fk) references paciente(id_pac) on delete set null,
    foreign key (id_sal_fk) references sala(id_sal) on delete set null,
    foreign key (id_fun_fk) references funcionario(id_fun) on delete set null,
    foreign key (id_tip_fk) references tipo(id_tip) on delete set null   
);

----------------------------------------------------
-- LOGIN PACIENTE
--------------------------------------------------------------------------------
create table login_paciente (
    id_lop int not null auto_increment primary key,
    email_lop varchar(200) not null,
    senha_lop varchar(200) not null,
    id_pac_fk int null,
    foreign key (id_pac_fk) references paciente(id_pac) on delete set null
);

--------------------------------------------------------------------------------
-- LOGIN FUNCIONARIO
--------------------------------------------------------------------------------
create table login_funcionario (
    id_lof int not null auto_increment primary key,
    email_lof varchar(200) not null,
    senha_lof varchar(200) not null,
    id_fun_fk int null,
    foreign key (id_fun_fk) references funcionario(id_fun) on delete set null
);

# inserts

-- tabela paciente
insert into paciente (nome_pac, cpf_pac, rg_pac, data_nascimento_pac, sexo_pac, telefone_pac, email_pac, cep_pac, rua_pac, numero_pac, bairro_pac)
values ('joão da silva', '123.456.789-00', 'mg1234567', '1985-05-10', 'masculino', '(69)99999-1111', 'joao.silva@email.com', '76920-000', 'rua das flores', '100', 'centro');

insert into paciente (nome_pac, cpf_pac, rg_pac, data_nascimento_pac, sexo_pac, telefone_pac, email_pac, cep_pac, rua_pac, numero_pac, bairro_pac)
values ('maria oliveira', '987.654.321-00', 'ro9876543', '1990-08-22', 'feminino', '(69)98888-2222', 'maria.oliveira@email.com', '76920-001', 'avenida brasil', '200', 'bairro novo');

-- tabela cargo
insert into cargo (nome_car, departamento_car, descricao_car, carga_horaria_car, data_criacao_car, data_atualizacao_car, observacoes_car)
values ('fisioterapeuta', 'saude', 'responsavel por atendimentos de fisioterapia', 40, '2025-01-01', '2025-01-15', 'cargo essencial');

insert into cargo (nome_car, departamento_car, descricao_car, carga_horaria_car, data_criacao_car, data_atualizacao_car, observacoes_car)
values ('recepcionista', 'administrativo', 'responsavel pelo atendimento inicial ao paciente', 44, '2025-01-02', '2025-01-16', 'cargo de apoio');

-- tabela funcionario
insert into funcionario (nome_fun, cpf_fun, rg_fun, data_nascimento_fun, telefone_fun, email_fun, tipo_vinculo_fun, registro_profissional_fun, especialidade_fun, subespecialidade_fun, certificados_fun, data_contratacao_fun, id_car_fk)
values ('ana costa', '111.222.333-44', 'ro123456', '1988-03-12', '(69)97777-3333', 'ana.costa@email.com', 'clt', 'crefito-12345', 'fisioterapia geral', 'ortopedia', 'curso pilates', '2025-02-01', 1);

insert into funcionario (nome_fun, cpf_fun, rg_fun, data_nascimento_fun, telefone_fun, email_fun, tipo_vinculo_fun, registro_profissional_fun, especialidade_fun, subespecialidade_fun, certificados_fun, data_contratacao_fun, id_car_fk)
values ('carlos pereira', '555.666.777-88', 'ro654321', '1992-07-25', '(69)96666-4444', 'carlos.pereira@email.com', 'pj', null, 'atendimento administrativo', null, null, '2025-02-05', 2);

-- tabela sala
insert into sala (nome_sal, numero_sal, capacidade_sal, tipo_sal, disponibilidade_sal, observacao_sal)
values ('sala ortopedia', '101', 2, 'atendimento fisioterapia', 'disponivel', 'equipada com aparelhos basicos');

insert into sala (nome_sal, numero_sal, capacidade_sal, tipo_sal, disponibilidade_sal, observacao_sal)
values ('sala pilates', '102', 5, 'atividade em grupo', 'ocupada', 'utilizada para exercicios coletivos');

-- tabela tipo
insert into tipo (nome_tip)
values ('consulta fisioterapia');

insert into tipo (nome_tip)
values ('sessao pilates');

-- tabela agenda
insert into agenda (data_age, horario_age, observacao_age, id_sal_fk, id_fun_fk, id_pac_fk, id_tip_fk)
values ('2025-03-01', '09:00:00', 'primeira avaliacao', 1, 1, 1, 1);

insert into agenda (data_age, horario_age, observacao_age, id_sal_fk, id_fun_fk, id_pac_fk, id_tip_fk)
values ('2025-03-02', '10:30:00', 'atividade em grupo', 2, 2, 2, 2);

-- tabela login_paciente
insert into login_paciente (email_lop, senha_lop, id_pac_fk)
values ('joao.silva@email.com', 'senha123', 1);

insert into login_paciente (email_lop, senha_lop, id_pac_fk)
values ('maria.oliveira@email.com', 'senha456', 2);

-- tabela login_funcionario
insert into login_funcionario (email_lof, senha_lof, id_fun_fk)
values ('ana.costa@email.com', 'senha789', 1);

insert into login_funcionario (email_lof, senha_lof, id_fun_fk)
values ('carlos.pereira@email.com', 'senha321', 2);

