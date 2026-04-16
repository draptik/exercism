import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LogLevels {
    
    public static String message(String logLine) {
        return logLine.replaceAll("^\\[.*]:\\s", "").trim();
    }

    public static String logLevel(String logLine) {
        String pattern = "^\\[(?<level>\\w+)\\]";
        Matcher m = Pattern.compile(pattern).matcher(logLine);
        if (m.find()) {
           return m.group("level").toLowerCase();
        }
        return logLine;
    }

    public static String reformat(String logLine) {
        String pattern = "^\\[(?<level>\\w+)\\]:\\s(?<message>.*)$";
        Matcher m = Pattern.compile(pattern).matcher(logLine);
        if (m.find()) {
            String lvl = "(" + m.group("level").toLowerCase() + ")";
            String msg = m.group("message").trim();
            return msg + " " + lvl;
        }
        return logLine;
    }
}
