/** @type {import('ts-jest').JestConfigWithTsJest} */
module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'node',
  transformIgnorePatterns: [     
    '/node_modules/(?!@dative-gpi/bones-ui)' // Ignore everything in node_modules except @dative-gpi/bones-ui  
  ]
};