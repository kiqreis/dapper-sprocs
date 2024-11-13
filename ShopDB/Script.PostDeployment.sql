/*
Modelo de Script Pós-Implantação							
--------------------------------------------------------------------------------------
 Este arquivo contém instruções SQL que serão acrescentadas ao script de compilação.		
 Use sintaxe SQLCMD para incluir um arquivo no script pós-implantação.			
 Exemplo:      :r .\myfile.sql								
 Use sintaxe SQLCMD para referenciar uma variável no script pós-implantação.		
 Exemplo:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists(SELECT 1 FROM dbo.Customer)
BEGIN
    INSERT INTO dbo.Customer(FirstName, LastName)
    VALUES('Jurandir', 'Silva'),
    ('Jureminha', 'Santos'),
    ('Astolfo', 'Pereira'),
    ('Lucrecio', 'Rodrigues'),
    ('Josefino', 'Barbosa')
END