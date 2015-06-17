﻿CREATE TABLE [dbo].[CodeToken] (
    [Id] [int] NOT NULL IDENTITY,
    [Code] [nvarchar](max),
    [ClientId] [int] NOT NULL,
    [UserName] [nvarchar](max),
    [Scope] [nvarchar](max),
    [Type] [int] NOT NULL,
    [TimeStamp] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.CodeToken] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[OAuth2Configuration] ADD [EnableCodeFlow] [bit] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[Client] ADD [AllowRefreshToken] [bit] NOT NULL DEFAULT 0
DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Client')
AND col_name(parent_object_id, parent_column_id) = 'NativeClient';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Client] DROP CONSTRAINT ' + @var0)
ALTER TABLE [dbo].[Client] DROP COLUMN [NativeClient]
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201302041414549_RefreshToken', 0x1F8B0800000000000400ED5DCD72E33612BE6FD5BE834AA7DD432C8F9D43764A4ECAF1CFC4B5F178CAF464CE300949A8E18F428033D6B3E5B08FB4AFB020298A00011000094A94D7378900BF6E028D46A3816EFCF7AFFFCC7F7989C2C937986294C417D37727A7D3098CFD2440F1F2629A91C50F3F4D7FF9F9EF7F9BDF04D1CBE48FAADE795E8FBE19E38BE98A90F5FBD90CFB2B18017C12213F4D70B220277E12CD4090CCCE4E4FFF357BF76E0629C494624D26F3C72C262882C51FFAF72A897DB8261908EF93008678FB9C967805EAE42388205E031F5E4C9F5628FE4AA04FB2149EDC059002918D0753FA0D278F709D60449214417CE2FD194E2797210294470F868BE964FDE3FBCF187A244DE2A5B7060481F069B386B47C01420CB75FF47EFDA3E9479D9EE51F3503719C100A97C49D1A65BAFB5CFAC137C5F7E46C151F7D31FD1026CF20A42DB440CB2C2DA9302FD057FE0D37DC03FAE8539AAC614A368F70B185B90BA69319FFDEACF9E2EE35E69D9C13FA2B26E767D3C9C72C0CC17308770D465BD4A3CD0D3FC01852DE60F0091002D3387FB7EC19816A83868708CC7F559468EF50D19B4E6ED10B0C7E87F192AC76D4EEC14BF584FE9C4E3EC7884A2A7D89A4199470D74EF90EE30CA69F537428D2B44F09F0C94D0450B87F1EAEE1026421F9E23D255F619C533F180FBFD1C172782E0A0E7E470B986B269DE0B72352A65094450E113D9C5C25C95704DDC03DC23F3394C29BD84F37EB52719570BF26490841DC15F011861BDA6B9F40A17B960893ADC6EA097F13E795AF424495CA157D8E16C8A7EAE63223AB5CCDF88E882C92D487748A48F18734C9D6F7307AA6BF5768DD173A97F04F494AFAF55A8E826D61E6B37A4A699D68BE78B73080657FBDDAE9A614A4C08D3CBA16BFBC72DD076EF07E4B7B7FEC651826DFA969156E9E12677AA240FB8208B5E61E21082347C01E0E6F93B413B3C60385CAF13D15BE14BD6AB36C195345CEE85AE7465AF95F37355713D4A13979F42EB76D42BB67EFD4BD4D14414ACCDF1B0F16D3C6539A61F26A4782D319E31E620C96D0837E9616B49D80E63D9F2F9CDDC20E6E6D31D31D0C8600BF86215C76C03396FD7AB2BE8704048080B761D0A9211FF2EE3F7B6B3CA37199C498927503F6087192D145CFC377FA6DB7D4CE73037B17AD43E423E20EF18AEA377B346301F410E518E60BAC3721ECD480D7082CE30453058E5F790BB24ABF98CD9F52E01726D8200D2B4CC3F8353569EE6C398CFBF7699545CF6B4A8DEC9FF635C47E8A38C7DB50C4CD07706D2CBDC997833EE6BC1AC72F5A3D56888C5318BD2EED7518C972644D1E4840779B224F0E76313837DFDEBC31D5B609E71FFB3FF009495AE285A4E09AAE7BDF1D8EF4D9E1489F8F45C5560A8B32FA0D51F3B49392BDEEA064AF5FAB92BD46781D82CD816C53661FBCE37EF12AF97E17FF96061E35EB7C172E35767BF0260ED6896BCBD964E49507270632DD4D18285763B5D8EF99B007FD14EEFFAB4BF75CA55C5AA5D36CFE1CD21351B6D49B9939D6958411F1ED380B0E457980816668D20628A50ADBF5B1349361B9DDE75FA410AF0A2BDDC9C10197AEE02D878E5DD605EAC0FEE51CBE6CD357A497F28F3AD40CACFDBC03F8858C566D7EE2F88CA309D5FE0665BE5AF708887647E1E8FA67BB84EF31428A23B088CA5F631D539EE7E63612F2AAF0A539AFDF6CAB9396D3D2939A83F224F889B4D6AC1D99B57F2590EAD3733A603A92B1045079CA48CF68712043CAA3E4A8860E4EDCE39620EB36C275444A0353022CDB18D681D57B791240D5469F0E94D9DF92A02A77BF74B092DD1D115D5649C72E73F441E49629D4E0347CB72256B38206AFE9A890410ACE0CB34654B79C1EA09A9DA518BBA95BAAD8762A6C57369F95512BDB07F39922BC657E0FD66BDA764CB8CBF6C9C42B635DAE7EF0EC234AA21263E6634960C98EDB1D256A0280256C94964D728B524C723FD733C8D5FA551009D5BA2BEC8A01B5DE6E1A4675CF54EFE6BFABDD3CF3A820A9FA6F10ABFBE296364F44F18A96823BF68D582E703C1F842095986757499845B1CAC46B7BBB0E9A6131EAA7E6484C100CC74EFDD8168B8F6A1141F972737459BC0A8B2E2BB7466F44A248F01B35AC2934624224141A35CC29C8A34E580AF21A16722746A1700228169B634B4252586C49B135B63A3A4542495DD99CAEE1414A96BAE12B363CB444B5F0945B2A9AD3AB435D58F0FAA91D1296436115D67CD650DBCD496426CC228D85757382329ABEB8C5C160F39661844E4154377B59600D3387ED9CC0A2F477C0D10FA93E23A8199823A2B3A5B6C845888E08593C36C7E2A3745838BEA483D6146375A4FA52AC664DAB11BE2321D3A8311A0D50ACE2071BF9662147054DDDC037871ACA76954716F196ACBC8E8DB5A50C1CE24D2E65350BD9E5438338A1E58B2C5A4976B8836B225985D18C86CA0735E054A88B3A2AE8E96741139863980085C8221155A8624D430C349250112B1D9BC1DC1A98A49CFBC5AAB63459BF9C4846EDB52B700F33D025DEE1C1C6BC55B455415A37FCAD11C7A1090ED4D75B27FD60FDAB0D0233EA53239471F4A3460B56715E126D5715D9624AF6CE457449255B3AFCA6BF48822FB76F996AAF5ED63455D968C60DB31F35D8D8318A5F2B48EAC68F31D238C6D081FA94DD0E1CAC53CD62EA8C7AD51C6AC86E5587CEB579549A75472304BAD03C97B2A0A76520052620C3F47F7DDE86C5A89F9A23B1877F592CF6B98D9F8039E4C87B069882D1489C2A48CFA9D651D230D1332D2F8F5DB2A4BE4D4B3FE691C9535B689E4B996AA76320573A8061644B942B5B9972B52470219B8DC83B4E79F245367C495DF5D67B0D8A903ABED5A455F6EF53557E03130CC731CE3CEF8076A6403BEB8476AE403B1F9156120F890DA698DA03E70A5A3AD5A487502AA7EB86721222F0DADEEEAF9CB818376EB2620B2C148C7068C6F6908C2C6C8D1BA19272737479081B8B2FAF617B044A65A28AA5E6C875E0198B583FB545AA025C44B4AAC41C51161EC6E2CACA5F9D47A03A843AF00AB0F3AAEF786CA6AE36B466E804D2A163F56DEE870E17EFC5DB504C81F5291036864B7214842DB6C4567B7625C5D67CB77AA755752CA9C8BDC78DA2F1A895FA68FA709A451E9C5610D12A17F5BBC3E89732E88C1B7BC59343E80377BE876D581867EB948FF6697E31415E1C4CFD78CFE34208B26856D951DF3ED9FDDF05596C031CF4178B08110F6595E9A4325CF2052226303AC92BE403A78A2EA92ADC83982EA1717982FB627A767AFA53E306920EB783CC300EC223B822A4B067B501A5B6692C1AB783C4DF40EAAF40FA8F08BCFCB3FF8D1F2EE064B778F4C355DFCCE104577ADB861364E97D17855C38BC3FA30B9EF2F68C2E60CABB339E516730DDBD195DA0ADB2387723A0BD2FA30B6CF3AE8C2E7D24DC94A10739C67B3206D1B98DEC2CDD45CFA5A435CFD8F7C562AEC5E80222BB12A3D7F0575D87D103547A15861EEF08AFC118C8F468BB0143395F3AB9D5A217BAF4A68A5E882D99062D708FEC468971EB56C545123D005597488CD4F4683D78DD1758BC38C2A1DE1CDDA511E390F4E3BA2B621C6DA61C79FC1511DD8194B9B6BA43CAF281F5F9523E6D9743391BCD9510E390B523BC0962C086D35D02E1B03DC77001C4202DD9CCC1D6CF07252685EDEBD312D25FDA001EC5BD0B47D0ADDC6A787F3D7AC4D71D0CD2A9EE3AD48191E35026A4B71174F30A737E965EEBEDD6FB0546B09297702CDC03E006EECC2DDCF990E3FEF039F8473EF22529F57B0E5E6603ABD3B69032497E17ADD49620BF97F8AA92DEF7026D26B27700C6E7CCEE05A84E38DFE8E70EE9E69D9BE66F53BC5BD35929AC814B344369ED9AB5BD97F82B33B177DEAB72E57569CFC0DE19714037CE0133AF0F324CD9A4EB2E6680A0CF0C6ABCD6B34E8DDE0BA9AF6120243B0F68DF11D7C9CEC514BB3C53BB73712DC7BC0C739B9747D9E8773CE72B9492FFBE49D0758CB4D495B1D32B81BA2253BAC093BAAA8CA5BE29D8F52D24AB266F1C2799DB750C69DF90F1E626F7BB8E35692D193BFD32C6EBD850D694B1E220D7BC8E1F75551943FB4F532FE362C874F6D2AF1E30DDBD8C5ECF94F84619F165743BE6CD6F499BAFEE3D3D769D355F84AFCBA4147A27DC17CF7CCF678F599CCFE0E53FBA4241CB1A624E31E3D20350835675EEE24552D907F4FB588EAA2ACDE3AB5B3D78994B38F0092DF621C6C5F6D01F20CCF23569F40C83BBF82123EB8C5C620CA3E7900B369ECFDAE917B70AF03CCF1F8A251776F109944D941B3D0FF1AF190A831DDFB712A347019177E3D6EEA55C79F98956B8DCEC903E26B121D0B6F9AEE11AC6B9883F41AA5673B5F1107BE01B54F3A66F43BEC5E6B97E4C4184B718F5FBF42F15BF207AF9F97F2F68258834950000, '5.0.0.net45')
