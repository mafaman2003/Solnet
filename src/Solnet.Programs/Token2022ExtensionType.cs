#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Solnet.Programs
{
    /// <summary>
    /// Token-2022 extension types.
    /// </summary>
    public enum Token2022ExtensionType : ushort
    {
        Uninitialized = 0,
        TransferFeeConfig = 1,
        TransferFeeAmount = 2,
        MintCloseAuthority = 3,
        ConfidentialTransferMint = 4,
        ConfidentialTransferAccount = 5,
        DefaultAccountState = 6,
        ImmutableOwner = 7,
        MemoTransfer = 8,
        NonTransferable = 9,
        InterestBearingConfig = 10,
        CpiGuard = 11,
        PermanentDelegate = 12,
        NonTransferableAccount = 13,
        TransferHook = 14,
        TransferHookAccount = 15,
        ConfidentialTransferFeeConfig = 16,
        ConfidentialTransferFeeAmount = 17,
        MetadataPointer = 18,
        TokenMetadata = 19,
        GroupPointer = 20,
        TokenGroup = 21,
        GroupMemberPointer = 22,
        TokenGroupMember = 23,
        ConfidentialMintBurn = 24,
        ScaledUiAmount = 25,
        Pausable = 26,
        PausableAccount = 27,
        PermissionedBurn = 28,
    }
}