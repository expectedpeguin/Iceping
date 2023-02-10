[![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/alexandrosntonas/Iceping?include_prereleases)](https://github.com/alexandrosntonas/Iceping/releases/latest)

# Welcome to Iceping

Iceping is a powerful and reliable tool for monitoring the availability and response time of TCP services. Utilizing TCP handshakes, Iceping provides accurate measurements in milliseconds, making it a valuable resource for network administrators.

With its straightforward console interface and advanced features, Iceping is a must-have tool for monitoring network services and ensuring their performance. Whether you're pinging a hostname or an IP address, Iceping provides you with the information you need to make informed decisions.

## Key Features
- Pings targets using either hostname or IP address
- Automatically resolves hostnames to IP addresses
- Provides response time measurements in milliseconds
- Gives comprehensive statistics on received, sent, and failed pings, along with percentage of loss
- Allows you to ping any port and receive its response time

## Easy to Use Console Interface
Iceping has been designed with simplicity in mind, offering a straightforward console interface that makes it easy to use. Whether you're an experienced network administrator or just starting out, Iceping is a tool that you can rely on.

## Accurate Measurements
With its advanced TCP handshake technique, Iceping provides accurate response time measurements in milliseconds, ensuring that you have the information you need to make informed decisions about your network's services.

## How to Use
Iceping can be run from the command line by passing the hostname or IP address, and the port number, as arguments.
To use Iceping, simply run the following command in your terminal:

```
iceping.exe <hostname/ip address> <port>
```

For example, to ping the host `1.1.1.1` on port `53`, you can use the following command:

```
iceping.exe 1.1.1.1 53
```

## Console Output Example
Here's an example of the console output when running Iceping for the host `1.1.1.1` on port `53`:
```
Pinging 1.1.1.1:
Connected to 1.1.1.1: time=12ms protocol=TCP port=53

Ping statistics for 1.1.1.1:
    Packets: Sent = 1, Received = 1, Lost = 0 (0% loss)
```

## System Requirements
Iceping is written in C# .NET Framework 4 and is supported by the following versions of Windows:

- Windows 7
- Windows 8
- Windows 8.1
- Windows 10
- Windows 11
- Windows Server 2008 R2
- Windows Server 2012
- Windows Server 2012 R2
- Windows Server 2016
- Windows Server 2019
- Windows Server 2022

Please make sure your system meets the above requirements before installing and using Iceping.