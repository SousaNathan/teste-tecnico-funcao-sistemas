CREATE PROCEDURE FI_SP_ConsBeneficiarios
    @IdCliente BIGINT
AS
BEGIN
    SELECT Id, Nome, CPF, IdCliente
    FROM Beneficiarios
    WHERE IdCliente = @IdCliente;
END
