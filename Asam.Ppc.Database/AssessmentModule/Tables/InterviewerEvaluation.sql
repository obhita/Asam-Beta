CREATE TABLE [AssessmentModule].[InterviewerEvaluation] (
    [InterviewerEvaluationKey]                         BIGINT NOT NULL,
    [Version]                                          INT    NOT NULL,
    [HasMaintainedBarbituatesDoseAtTherapeuticLevels]  BIT    NULL,
    [HasMaintainedMethadoneDoseAtTherapeuticLevels]    BIT    NULL,
    [HasMaintainedNicotineDoseAtTherapeuticLevels]     BIT    NULL,
    [HasMaintainedOtherDrugDoseAtTherapeuticLevels]    BIT    NULL,
    [HasMaintainedOtherOpiatesDoseAtTherapeuticLevels] BIT    NULL,
    [HasMaintainedSedativeDoseAtTherapeuticLevels]     BIT    NULL,
    [HasMaintainedStimulantDoseAtTherapeuticLevels]    BIT    NULL,
    [IsVisited]                                        BIT    NOT NULL,
    PRIMARY KEY CLUSTERED ([InterviewerEvaluationKey] ASC)
);














GO


