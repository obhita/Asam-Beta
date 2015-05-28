CREATE TABLE [ScoringModule].[CommonScoresAddictionSeverityIndexCompositeScores] (
    [CommonScoresKey] BIGINT        NOT NULL,
    [AsiAspect]       NVARCHAR (50) NULL,
    [Score]           FLOAT (53)    NULL,
    CONSTRAINT [CommonScoresAddictionSeverityIndexCompositeScores_CommonScores_FK] FOREIGN KEY ([CommonScoresKey]) REFERENCES [ScoringModule].[CommonScores] ([CommonScoresKey])
);


GO
CREATE NONCLUSTERED INDEX [CommonScoresAddictionSeverityIndexCompositeScores_CommonScores_FK_IDX]
    ON [ScoringModule].[CommonScoresAddictionSeverityIndexCompositeScores]([CommonScoresKey] ASC);

