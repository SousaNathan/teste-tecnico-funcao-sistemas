CREATE PROCEDURE FI_SP_IncBeneficiario
    @Nome NVARCHAR(100),
    @CPF NVARCHAR(11),
    @IdCliente BIGINT
AS
BEGIN
    INSERT INTO Beneficiarios (Nome, CPF, IdCliente)
    VALUES (@Nome, @CPF, @IdCliente);
END
