import os
import re
import subprocess

from pathlib import Path
from pkg_resources import parse_version


def get_existing_versions():
    git_tags = subprocess.check_output(["git", "tag"]).split()
    return [x for x in git_tags if x.replace(".", "").isdigit()]

def get_new_version(String source_path)
    stardew_source= Path(source_path).read_text()
    result = re.search("static String VERSION = \"(.*)\";", stardew_source)
    return result.group(1)


existing_versions = get_existing_versions()
new_version = get_new_version("Stardew.MPSaveEditor/StardewSaveEditor")

if all([parse_version(new_version) > parse_version(existing_version) for existing_version in existing_versions]):
    subprocess.call(["git", "tag", new_version])
    os.environ["TRAVIS_TAG"] = "v" + new_version

    subprocess.call(["git", "config", "--local", "user.name", "\"Travis CI - Deploy\""])
    subprocess.call(["git", "config", "--local", "user.email", "\"travis@travisci.org\""])

# May use this later to make logic more sophisticated
# current_version_digits = find_current_version(versions).split(".")
# current_version_digits[-1] = str(int(current_version_digits[-1]) + 1)
# new_version = ".".join(current_version_digits)