import sys
import os
import subprocess
import re
from concurrent.futures import ThreadPoolExecutor

tvShowTotalLengthAppBin = os.getenv("GET_TVSHOW_TOTAL_LENGTH_BIN")
if not tvShowTotalLengthAppBin:
    print("Missing GET_TVSHOW_TOTAL_LENGTH_BIN environment variable")
    input("")
    sys.exit(1)

if not os.path.exists(tvShowTotalLengthAppBin):
    print(f"Could not find {tvShowTotalLengthAppBin}")
    input("")
    sys.exit(1)


def get_length_for_show(name):
    result = subprocess.run([tvShowTotalLengthAppBin, name], capture_output=True, text=True)

    if result.returncode != 0:
        print(f"Could not get info for {name}")
        return name, None

    match = re.search(r'\d+', result.stdout)
    if match:
        length = int(match.group())
        return name, length
    else:
        return name, None


def format_time(minutes):
    return f"{minutes // 60} hours {minutes % 60} minutes"


lines = []
for line in sys.stdin:
    line = line.strip()
    if line == "q":
        break
    if line:
        lines.append(line)

with ThreadPoolExecutor() as executor:
    results = list(executor.map(lambda line: get_length_for_show(line), lines))

valid_results = [(name, length) for name, length in results if length is not None]

if valid_results:
    max_result = max(valid_results, key=lambda x: x[1])
    min_result = min(valid_results, key=lambda x: x[1])

    print(f"The shortest show: {min_result[0]} ({format_time(min_result[1])})")
    print(f"The longest show: {max_result[0]} ({format_time(max_result[1])})")
