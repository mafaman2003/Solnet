# Solnet Detailed Changelog

This changelog is derived from the commit history on github.

- Explicit release/version commits are used as boundaries where they exist.
- `v8.9.0` is inferred from the current head commit, per the latest version note.
- Commit tags list the primary implementing commit and notable follow-up commits where a feature landed across multiple changes.
- Older sections become broader where the commit log stops including clear release tags.

## v8.9.0

Primary commit: `c01471a`

### Address Lookup Table support

- Added PDA derivation helpers for lookup tables using authority plus recent slot. `[c01471a]`
- Added a `CreateLookupTable(authority, payer, recentSlot)` overload that derives the ALT address and bump internally. `[c01471a]`
- Preserved explicit ALT creation for callers that already have the derived table address. `[c01471a]`
- Added an `ExtendLookupTable` overload that supports authority-only extension without forcing payer and system-program accounts. `[c01471a]`
- Added ALT instruction decoding and registered the ALT program with the shared instruction decoder. `[c01471a]`

### Versioned messages and transactions

- Added first-class version handling in versioned message serialization. `[c01471a]`
- Replaced the hardcoded v0 prefix with `0x80 | version`. `[c01471a]`
- Preserved parsed message versions during deserialization instead of rejecting non-zero versions. `[c01471a]`
- Added compilation support for v0 transactions that consume address table lookups. `[c01471a]`
- Added support for v1 messages and versioned transactions. `[c01471a]`
- Added null-safe serialization for address-table lookups. `[c01471a]`

### SPL Token-2022 coverage

- Added a dedicated `Token2022Program` surface with Token-2022 program and native mint ids. `[c01471a]`
- Added a public `Token2022ExtensionType` enum aligned with the Rust interface. `[c01471a]`
- Implemented shared token builders against Token-2022, including transfer, mint, burn, authority, checked, sync-native, and multisig flows. `[c01471a]`
- Added missing newer builders such as `InitializeAccount2`, `InitializeAccount3`, `InitializeMultiSignature2`, `InitializeMint2`, `GetAccountDataSize`, `InitializeImmutableOwner`, `AmountToUiAmount`, and `UiAmountToAmount`. `[c01471a]`
- Added Token-2022-specific support for `InitializeMintCloseAuthority` and `Reallocate`. `[c01471a]`
- Registered Token-2022 with the shared instruction decoder. `[c01471a]`

### Legacy token parity and ATA updates

- Added legacy `TokenProgram` builders for `InitializeAccount2`, `InitializeAccount3`, and `InitializeMint2`. `[c01471a]`
- Extended legacy token decoding to recognize newer shared instructions such as `InitializeMintCloseAuthority` and `Reallocate`. `[c01471a]`
- Added missing shared encoders in `TokenProgramData` for the newer opcode range. `[c01471a]`
- Corrected `UiAmountToAmount` payload handling to use raw UTF-8 bytes. `[c01471a]`
- Added associated-token-account derivation and creation overloads that accept a caller-supplied token program id, while keeping the legacy token program as the default path. `[c01471a]`

### Tests and documentation

- Added a README example covering create and extend flows for Address Lookup Tables. `[c01471a]`
- Added focused tests for ALT derivation and decoding, versioned message v0/v1 behavior, ALT-backed versioned transaction compilation, Token-2022 builders and decoding, Token-2022 ATA derivation, and legacy token parity. `[c01471a]`

## v8.7.0

Release commit: `e8df87b`

### Transaction correctness and signing fixes

- Fixed transaction signature verification failures caused by inconsistent signing order during serialization. `[e6856f0]`
- Updated signature ordering to follow account-key ordering. `[f2e679a]`

### Token and program fixes

- Fixed token mint freeze-authority handling. `[4e9f0bc, 871cd99]`
- Fixed Token Swap program issues. `[72ef471]`
- Corrected a Token Swap example. `[3218ab5]`
- Cleaned up a copy/paste mistake in the token-mint freeze-authority path. `[871cd99]`

### Release outcome

- `v8.7.0` is primarily a stabilization release focused on signature correctness and targeted token-program regressions.

## v8.5.0

Release commits: `33173c8`, `ae8872f`

### Major SDK surface growth

- Added Stake Pool program support and staking-related classes. `[30fa28f, 0eee923, 0859636]`
- Added the Account Compression program. `[6e5bf67]`
- Added Governance program support. `[3c3d7f5, 1e0981a]`
- Added the Address Lookup Table program surface. `[023e107, 80979ad]`

### RPC and transaction model improvements

- Updated `getTransaction` to support additional response encodings. `[33173c8, 603a7e5]`
- Added support for `loadedAddresses`, rewards, and dynamic version JSON types in transaction responses. `[33173c8, 603a7e5, ab11a4c]`
- Reorganized transaction models into their own space. `[603a7e5]`
- Updated examples and decoder paths to work with `TransactionInfo`. `[ab11a4c]`

### Dependency and platform hardening

- Removed BouncyCastle and Chaos dependencies in favor of maintained in-house cryptography dependencies. `[33173c8, dca105c, 023e107]`
- Replaced additional crypto usage with `System.Security.Cryptography` where possible. `[80979ad, bcb3144]`
- Cleaned warnings and pruned a commit from the BPF Loader merge during the release process. `[ae8872f, 9d85e07]`

### Quality and maintenance

- Expanded Stake Pool tests and fixed missing methods and instruction encoding details. `[26f6f79, 3989149, 0859636]`
- Improved rate-limiter behavior and tests, including async/await coverage. `[632c6be, 99504b6, f82bf57, 28bc01c]`
- Cleaned up obsolete tests, improved code coverage, updated comments, and refreshed README content. `[7fcefcd, da1be54, 975c651, 6839cde]`

### Release outcome

- `v8.5.0` marks a large feature release that broadened program coverage, modernized transaction decoding, and reduced cryptography dependency risk.

## Post-v6 platform expansion before v8.5.0

This stretch of history does not include clean version markers for every release, but it shows the work that led into the later 8.x line.

### Runtime and dependency modernization

- Migrated toward Agave v2.0 and removed deprecated SDK code. `[bcb3144]`
- Upgraded parts of the stack to .NET 8. `[d9bf1b4, dca105c, 031bf37]`
- Moved away from BouncyCastle and Chaos.NaCl toward maintained Bifrost-backed cryptography. `[dca105c, 80979ad, 023e107]`

### Versioned transaction adoption

- Added versioned transactions to the RPC client. `[012e10e]`
- Added `GetTransaction` and `GetBlock` support for versioned transactions. `[eac7430]`
- Added Compute Budget program support and priority-fee handling. `[2340627, 21fdbce, 9a1f26e]`
- Updated tests and models to handle versioned transaction payloads. `[868aff4, 24d8628]`

### New program areas and infrastructure

- Added Governance program implementations and client structures. `[3c3d7f5, 1428d04, 861626e, 031990f]`
- Added Address Lookup Table program groundwork before the broader `v8.9.0` completion work. `[023e107, 80979ad]`
- Added BPF Loader program support. `[884de96, 24d5cd8]`
- Added signature verification during transaction deserialization. `[5c9e0d0]`

### Wallet, account, and API polish

- Added account initialization from Base58 secret keys. `[a2161f9]`
- Aligned account ordering with `web3.js`. `[c164d5d]`
- Tightened `PublicKey` validation behavior. `[e61b309, cf7067e]`
- Added new RPC helpers such as `getLatestBlockhash`, `isBlockhashValid`, `getFeeForMessage`, and `getHighestSnapshotSlot`. `[cadf19f, e973e1a]`

## v6.x maturity cycle

### RPC client and batching

- Added batch RPC composition, response modeling, callbacks, and auto-execution behavior. `[c6a6e59, e589d40, 37ba92e, c590a31, c3612d3]`
- Added primitive rate limiting and later integrated it into the RPC client. `[481ff7e, af0dce9]`
- Split `BaseClient` into readonly and transactional responsibilities. `[6db5f56]`
- Improved program-error propagation, request/response inspection, and error parsing. `[14cd765, ea7a995, 5c4b6c5, 4c00689]`
- Added support for custom `HttpClient` injection. `[4ed08ca, 5b8e376]`

### Transaction building and decoding

- Added instruction decoding, transaction/message decoding, decompile/recompile flows, and a transaction-instruction factory. `[7826cc9, a28b60e, f573848, 4e4a496]`
- Added `AddSignature` support on `TransactionBuilder`. `[ce2d198]`
- Fixed multi-signer and repeated-account-key edge cases. `[6f756e3, 36630dd]`
- Improved signing behavior and serialization correctness. `[3e6b75a, b65c2f2, afe5c73]`

### Token, wallet, and program coverage

- Added Token Wallet abstractions, token metadata support, and more token helper methods. `[64fcb52, 1788c94, f5b97d8, e7a67a1]`
- Added Name Service, Stake Program, Token Swap, Shared Memory, Associated Token Account, and Memo program support. `[7a6520f, bc4329c, 8369ac1, af23553, 9ffabbf, 85fbc89]`
- Added token mint and token account entities plus multisig deserialization. `[4d55c47, b1b0186]`
- Added `SyncNative`, approve/revoke flows, and broader token-program parity work. `[31d9f58, f1777ba, a3bfc88]`

### Public key and derivation improvements

- Refactored PDA and derivation methods into `PublicKey`. `[2cdff90]`
- Added `IsValid` and `IsOnCurve` helpers. `[cf7067e]`
- Renamed nonce-related PDA return values to bump where appropriate. `[2b2926a, 3e6b75a]`

### Release outcome

- The v6.x period is where Solnet became a broader SDK platform rather than a narrow RPC wrapper, especially through batching, rate limiting, transaction decoding, and expanded on-chain program support.

## v0.4.x feature expansion

### SDK breadth

- Added Token Wallet, WellKnownTokens, token metadata extensions, and additional token-account convenience APIs. `[64fcb52, a806471, 6840dfc, f5b97d8]`
- Added parsed token-account subscriptions and more program-subscribe filters. `[f1ba229, 9dd423a]`
- Added memo-program support and ATA examples. `[85fbc89, 211c721]`

### Reliability improvements

- Added handling for HTTP 4xx RPC responses. `[0ae40f6, 7faf8d3, e295b0e]`
- Added null checks on key constructors. `[3d82588]`
- Fixed `getProgramAccounts` edge cases and JSON marshalling issues. `[9288a51, 7f2ea87]`
- Improved request-result compatibility and data-dictionary support. `[8b00ace, aae5d4c]`

### Developer ergonomics

- Expanded README examples and hello-world docs. `[ad26e1f, a8e3aaf, 2c987eb]`
- Added more batching methods and missing documentation. `[be5da8e]`
- Added async execution variants and generalized client abstractions for library authors. `[86761c5, 2ce782d]`

## v0.3.x architecture shift

### Core refactors

- Refactored accounts, keys, account metas, builders, and program implementations. `[93b5684, f573848]`
- Improved key-constructor performance via lazy initialization. `[b6a90f9]`
- Added encoding/decoding utilities and bit-mask helpers. `[c24a32a, 61376e9]`

### Transaction and program support

- Added missing token-program methods. `[8045297]`
- Added associated-token-account program support. `[9ffabbf]`
- Added durable nonce support and examples. `[7826cc9, 211c721]`
- Added missing RPC methods deprecated in v1.7 and removed in v1.8. `[1d01191]`

### Observability and streaming

- Added metrics. `[70d8fbf]`
- Improved websocket/streaming client behavior with connection events, reconnection, and disposal. `[46e2f4f, 672249b]`

## v0.2.x and v0.1.x foundation

### Initial platform build-out

- Bootstrapped the base RPC library, wallet, keystore, and streaming client. `[e6f2ba2, c4af196, 675736f]`
- Added account subscriptions, log subscriptions, slot subscriptions, and root subscriptions. `[c10043d, 8e3edb0, c8f4912, bc66669]`
- Added core RPC methods for blocks, epochs, fees, inflation, vote accounts, stake activation, health, leader schedule, and more. `[14d6220, a1fb441, 51d8d03, 43cf099, 3db161a, 04bf519, 1143a62, f80253d, c22e863, c694e33]`
- Added tests, CI, Cake build integration, coverage publishing, and repository templates. `[52487f9, d918f32, 2478904, 67610e9, 33b0751, 2aad0c9, 5c4cfdc]`

### Early transaction and wallet work

- Added signatures, transaction models, account helpers, and key-generation support. `[a81d695, bc68ee4, ae12bc2, 74a5e64]`
- Added wallet compatibility with sollet and `solana-keygen`-style storage. `[83cd059, c4af196]`
- Removed early dependency and project-structure issues while documenting the initial API surface. `[7a4bbf4, 2134a4f, 2759d87, 9fedd44, c80dc08]`
