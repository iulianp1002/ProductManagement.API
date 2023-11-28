CREATE TABLE [dbo].[Produse] (
    [CodIdx]           NVARCHAR (20)  NOT NULL,
    [CodIdxAlt]        NVARCHAR (20)  NOT NULL,
    [CodMagazin]       NVARCHAR (20)  NOT NULL,
    [Denumire]         NVARCHAR (150) NULL,
    [DataInregistrare] DATETIME       NULL,
    [Cantitate]        INT            NULL,
    [PretUnitar]       INT            NULL,
    CONSTRAINT [PK_Produse] PRIMARY KEY CLUSTERED ([CodIdx] ASC, [CodIdxAlt] ASC, [CodMagazin] ASC)
);

