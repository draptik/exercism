#1/bin/sh
BASENAME='queen_attack'
CODE=${BASENAME}.pl
TESTCODE=${BASENAME}_tests.plt

swipl -f ${CODE} \
    -s ${TESTCODE} \
    -g run_tests,halt -t 'halt(1)'

