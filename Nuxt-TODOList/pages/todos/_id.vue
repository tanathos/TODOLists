<template>
  <div class="xl:w-6/12 border-2 todo-body">
    <button id="doneTodo" class="p-2" @click="onDoneClick">
      Done
    </button>
    <h2>{{ todo.title }}</h2>
    <pre>{{ todo.description }}</pre>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "nuxt-property-decorator";

@Component
export default class TodoPage extends Vue {
  todo: any = {};

  async fetch () {
    this.todo = await this.$axios.$get(`/todoapi/todos/${this.$route.params.id}`);
  }

  async onDoneClick () {
    try {
      await this.$axios.$put(`/todoapi/todos/${this.todo.id}/done`);
    } catch (error) {

    }
  }

  created () {
  }
}
</script>
