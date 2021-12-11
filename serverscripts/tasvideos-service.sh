### BEGIN INIT INFO
# Provides:             tasvideos
# Required-Start:       mysql nginx postgresql redis-server
# Required-Stop:        mysql nginx postgresql redis-server
# Should-Start:         $local_fs $network
# Should-Stop:          $local_fs $network
# Default-Start:        3 4 5
# Default-Stop:         0 1 2 6
# Short-Description:    TASVideos website server 
# Description:          TASVideos website server, .net and Kestrel
### END INIT INFO

WWW_USER=tasvideos
DNXRUNTIME=/usr/bin/dotnet
APPROOT=/home/tasvideos/tasvideos/TASVideos

PIDFILE=/home/tasvideos.pid

# fix issue with DNX exception in case of two env vars with the same name but different case
TMP_SAVE_runlevel_VAR=$runlevel
unset runlevel

start() {
  if [ -f $PIDFILE ] && kill -0 $(cat $PIDFILE); then
    echo 'Service already running or was not stopped correctly.' >&2
    return 1
  fi
 
  echo 'Starting service...' >&2
  #cd $APPROOT
  #$DNXRUNTIME restore

  # dotnet run --project "/home/tasvideos/tasvideos/TASVideos" --urls "http://127.0.0.1:5000/" --environment "Staging" --StartupStrategy Minimal
  su -c "start-stop-daemon -SbmCv -x /usr/bin/nohup -p \"$PIDFILE\" -d \"$APPROOT\" -- \"$DNXRUNTIME\" run --project $APPROOT --urls \"http://127.0.0.1:5000/\" --environment \"Staging\" --StartupStrategy Minimal -c Release --no-build --launch-profile \"Staging\"" $WWW_USER
  chown root:root $PIDFILE
  echo 'Service started' >&2
}

stop() {
  if [ ! -f "$PIDFILE" ] || ! kill -0 $(cat "$PIDFILE"); then
    echo 'Service not running' >&2
    return 1
  fi
  echo 'Stopping service...' >&2
  su -c "start-stop-daemon -K -p \"$PIDFILE\"" $WWW_USER 
  rm -f "$PIDFILE"
  echo 'Service stopped' >&2
}

case "$1" in
  start)
    start
    ;;
  stop)
    stop
    ;;
  restart)
    stop
    start
    ;;
  *)
    echo "Usage: $0 {start|stop|restart}"
esac

export runlevel=$TMP_SAVE_runlevel_VAR