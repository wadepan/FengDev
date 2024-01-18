﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "TestUsers are not designed to be extended", Scope = "member", Target = "~P:IdentityServer.TestUsers.Users")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Main catches and logs all exceptions by design")]
[assembly: SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "ExternalProvider is nested by design", Scope = "type", Target = "~T:IdentityServer.Pages.Login.ViewModel.ExternalProvider")]
[assembly: SuppressMessage("Design", "CA1054:URI-like parameters should not be strings", Justification = "Consistent with the IdentityServer APIs")]
[assembly: SuppressMessage("Design", "CA1056:URI-like properties should not be strings", Justification = "Consistent with the IdentityServer APIs")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "No need to change migrations, as they are generated code", Scope = "namespaceanddescendants", Target = "~N:IdentityServer.Migrations")]
[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "This namespace is just for organization, and won't be referenced elsewhere", Scope = "namespace", Target = "~N:IdentityServer.Pages.Error")]
[assembly: SuppressMessage("Naming", "CA1724:Type names should not match namespaces", Justification = "Namespaces of pages are not likely to be used elsewhere, so there is little chance of confusion", Scope = "type", Target = "~T:IdentityServer.Pages.Ciba.Consent")]
[assembly: SuppressMessage("Naming", "CA1724:Type names should not match namespaces", Justification = "Namespaces of pages are not likely to be used elsewhere, so there is little chance of confusion", Scope = "type", Target = "~T:IdentityServer.Pages.Extensions")]
[assembly: SuppressMessage("Naming", "CA1724:Type names should not match namespaces", Justification = "Namespaces of migrations are not likely to be used elsewhere, so there is little chance of confusion", Scope = "type", Target = "~T:IdentityServer.Migrations.ConfigurationDb.Configuration")]
[assembly: SuppressMessage("Naming", "CA1724:Type names should not match namespaces", Justification = "Namespaces of migrations are not likely to be used elsewhere, so there is little chance of confusion", Scope = "type", Target = "~T:IdentityServer.Migrations.PersistedGrantDb.Grants")]
[assembly: SuppressMessage("Performance", "CA1805:Do not initialize unnecessarily", Justification = "This is for clarity and consistency with the surrounding code", Scope = "member", Target = "~F:IdentityServer.Pages.Logout.LogoutOptions.AutomaticRedirectAfterSignOut")]
[assembly: SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "No need for ConfigureAwait in ASP.NET Core application code, as there is no SynchronizationContext.")]
