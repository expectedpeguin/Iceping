[![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/alexandrosntonas/Iceping?include_prereleases)](https://github.com/alexandrosntonas/Iceping/releases/latest)

# IcePing - A Powerful Network Utility

IcePing is a powerful network utility designed to assist with TCP connections and web HTTP/HTTPS requests. With IcePing, you can unleash the full potential of these features to enhance your networking capabilities.

With its straightforward console interface and advanced features, Iceping is a must-have tool for monitoring network services and ensuring their performance. Whether you're pinging a hostname or an IP address, Iceping provides you with the information you need to make informed decisions.

## Key Features
- Pings targets using either hostname or IP address
- Automatically resolves hostnames to IP addresses
- Provides response time measurements in milliseconds
- Gives comprehensive statistics on received, sent, and failed pings, along with percentage of loss
- Allows you to ping any port and receive its response time
- HTTP/HTTPS requests to any url of your choice
- Get statistics about the failed and successed requests based on status code

## Easy to Use Console Interface
Iceping has been designed with simplicity in mind, offering a straightforward console interface that makes it easy to use. Whether you're an experienced network administrator or just starting out, Iceping is a tool that you can rely on.

## Accurate Measurements
With its advanced TCP handshake technique, Iceping provides accurate response time measurements in milliseconds, ensuring that you have the information you need to make informed decisions about your network's services.

## Usage
## TCP Connection
To establish a TCP connection, use the following command:

```
iceping.exe TCP <host> <port>
```

For example, to ping the host `1.1.1.1` on port `53`, you can use the following command:

```
iceping.exe TCP 1.1.1.1  53
```

- `<host>`: Specify the target host, whether it be a hostname (e.g., example.com) or an IP address (0.0.0.0).
- `<port>`: Choose any integer between 1 and 65535.

## Web HTTP/HTTPS Request
To perform web HTTP/HTTPS requests, use the command below:
```
icerequest.exe HTTP <url> <method> <rps> <cps>
```
- `<url>`: The URL of the target endpoint.
- `<method>`: The HTTP method to use (e.g., GET, POST, DELETE).
- `<rps>`: Number of requests per second (default: 1).
- `<cps>`: Number of connections per second (default: 1).

## Methods
- GET
- POST
- PUT
- DELETE
- HEAD
- PATCH

## Statistics
IcePing provides statistics to help you analyze the results of your operations. For TCP connections, press Ctrl+C to view the ping statistics. For web HTTP/HTTPS requests, press Ctrl+C to view the request statistics.

## Contribution
Contributions to IcePing are welcome. If you have any enhancements or additions to suggest, please submit a pull request.

Thank you for your understanding, and I shall maintain professionalism in all further interactions. Should you require any further assistance, please do not hesitate to ask.

## System Requirements
Iceping is written in C# .NET Framework 4 and is supported by the following versions of Windows:

- Windows 7 SP1
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
