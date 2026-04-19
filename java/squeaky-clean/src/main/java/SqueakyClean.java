import java.util.regex.Matcher;
import java.util.regex.Pattern;

class SqueakyClean {
    static String clean(String identifier) {
        // Ignore 1 and 3 letter inputs
        if (identifier.length() == 1 || identifier.length() == 3) {
            return identifier;
        }

        // Space -> underscore
        String result = identifier.replace(' ', '_');

        // Kebab -> camelCase
        String patternKebab = "(?<pre>.*)(?<kebab>-\\w)(?<post>.*)";
        Matcher m = Pattern.compile(patternKebab).matcher(result);
        if (m.find()) {
            String upper = m.group("kebab").substring(1).toUpperCase();
            result = m.group("pre") + upper + m.group("post");
        }

        // leetspeak
        result = result
                .replace('4', 'a')
                .replace('3', 'e')
                .replace('0', 'o')
                .replace('1', 'l')
                .replace('7', 't');

        // Remove non-letters
        result = result.replaceAll("\\W", "");

        return result;
    }
}
