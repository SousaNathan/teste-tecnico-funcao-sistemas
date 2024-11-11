CREATE PROCEDURE FI_SP_DelBeneficiarios
    @IdCliente BIGINT
AS
BEGIN
    DELETE FROM Beneficiarios
    WHERE IdCliente = @IdCliente;
END
