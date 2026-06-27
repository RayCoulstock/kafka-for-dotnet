# Lab 02: Producers

## Learning objectives

- Understand the Kafka concept introduced in this module.
- Run the relevant training script or .NET demo.
- Inspect results in Kafka UI and from the terminal.

## Explanation

This lab builds on the previous environment. Do not recreate the Codespace unless instructed by the trainer. Prefer the scripts in `scripts/` over long Docker commands.

## Commands

```bash
./scripts/up-basic.sh
./scripts/create-topics.sh
```

Run the matching C# project from `apps/dotnet` when your instructor reaches that section.

## Expected output

- Kafka containers are healthy.
- Kafka UI shows the local cluster.
- Topics and records created in the lab are visible.

## Troubleshooting

See `TROUBLESHOOTING.md`. The most common fix is `./scripts/reset.sh` followed by the lab startup script.

## Challenge exercises

- Change a topic name or partition count and observe the result.
- Add logging to the C# sample to print keys, partitions, and offsets.

## Extension exercises

- Add command-line arguments to make the sample configurable.
- Compare behavior before and after stopping one service.
