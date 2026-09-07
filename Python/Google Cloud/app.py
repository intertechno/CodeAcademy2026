import os
from flask import Flask

app = Flask(__name__)

@app.route("/")
def hello():
    return "Hello from Docker and Google Cloud Run!"

@app.route("/info")
def info():
    return {
        "service": os.environ.get("K_SERVICE", "running-locally"),
        "revision": os.environ.get("K_REVISION", "local"),
        "port": os.environ.get("PORT", "8080")
    }

if __name__ == "__main__":
    port = int(os.environ.get("PORT", 8080))

    app.run(
        host="0.0.0.0",
        port=port
    )
