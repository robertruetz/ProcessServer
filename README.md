# ProcessServer
Server that handles starting, interacting with and stopping Windows processes.

* Currently hardcoded to listen at localhost:1984
* Communication done through JSON string that deserializes into a ProcessRequest struct
<pre><code>struct ProcessRequest
{
        string action  -- "start", "send" or "stop"
        string path  -- "Path to exe you want to start"
        string args -- "String representing arguments to pass into the process"
}
</code></pre>

**NOTE: CURRENTLY DOES NOT ACTUALLY RUN PROCESSES...YET**
