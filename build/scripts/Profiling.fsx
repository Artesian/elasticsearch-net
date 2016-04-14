﻿#I @"../../packages/build/FAKE/tools"
#r @"FakeLib.dll"
open Fake

#load @"Paths.fsx"

open System
open System.IO
open System.Diagnostics
open Paths

module Profiler =
    let private profiledApp = sprintf "%s/%s" (Paths.BinFolder("Profiling")) "Profiling.exe"
    let private snapShotOutput = Paths.Output("ProfilingSnapshot.dtp")
    let private snapShotStatsOutput = Paths.Output("ProfilingSnapshotStats.html")
    let private profileOutput = Paths.Output("ProfilingReport.xml")
    let private patternInput = Paths.Build("profiling/pattern.xml")

    let Run() = 
        // Profile, extract Stats, create Report
        // Tooling.DotTraceProfiler.Exec [@"/app=" + profiledApp; "/profiling_type=sampling"; snapShotOutput; @"/timeout=600"; @"/use_api"; @"/transparent_exit_code"]
        // Tooling.DotTraceSnapshotStats.Exec [snapShotOutput; snapShotStatsOutput; @"/full"]
        // Tooling.DotTraceReporter.Exec [@"/reporting"; snapShotOutput; patternInput; profileOutput]

        Tooling.execProcessWithTimeout profiledApp [] (TimeSpan.FromMinutes 10.) |> ignore
    
module Benchmarker =
   let private benchmarkingApp = Paths.Tool("NBench.Runner/lib/net45/NBench.Runner.exe")
   
   // run against the net45 assembly as the dnx build does not output references in the
   // same location
   let private testAssembly = Paths.Source("Tests/bin/Net45/Release/Tests.dll")

   let Run() =
        Tooling.execProcess 
            benchmarkingApp 
            [testAssembly; sprintf "output-directory=%s" (Paths.Output("Benchmarking"))] |> ignore
